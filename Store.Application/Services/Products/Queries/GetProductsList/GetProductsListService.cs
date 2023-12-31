﻿using FluentFTP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common;
using Store.Common.Constant.FileTypeManager;
using Store.Common.Constant.NoImage;
using Store.Common.Constant.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetProductsList
{
    public class GetProductsListService : IGetProductsListService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;

        public GetProductsListService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
        {
            _context = context; 
            _configuration= configuration;
            _language=language;
        }
        public async Task<ResultGetProductsDto> Execute(RequstGetProductsDto requstGetProducts)
        {
            try
            {
                string languageId = _language.Execute().Result.Data.Id ?? "";
                if (string.IsNullOrEmpty(languageId))
                {
                    return new ResultGetProductsDto
                    {
                    };
                }
                string BaseUrl = _configuration.GetSection("BaseUrl").Value;
                var listProducts = _context.Products.Include(e => e.Category).Where(p=>p.LanguageId==languageId).AsQueryable();
                if(!string.IsNullOrEmpty(requstGetProducts.SearchKey))
                {
                    listProducts = listProducts.Where(e => e.Name.Contains(requstGetProducts.SearchKey));
                }
                int RowsCount = 0;
                var Products=listProducts.
                    OrderByDescending(i => i.InsertTime)
                     .Select(
                p => new ProductsListDto
                {
                    Id = p.Id,
                    Category = p.Category.Name,
                    IsActive = p.IsActive,
                    Name = p.Name,
                    Pic = string.IsNullOrEmpty(p.MinPic) ? ImageProductConst.NoImage : BaseUrl + p.MinPic,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    InsertTime = p.InsertTime
                }
                ).ToPaged(requstGetProducts.Page, requstGetProducts.PageSize, out RowsCount).ToList();
                return new ResultGetProductsDto(){
                Products = Products,
                Rows= RowsCount,
                Pageinate = Pagination.PaginateAdmin(requstGetProducts.Page, requstGetProducts.PageSize, RowsCount, "products", requstGetProducts.SearchKey, requstGetProducts.Tag, requstGetProducts.Category),
                };
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
