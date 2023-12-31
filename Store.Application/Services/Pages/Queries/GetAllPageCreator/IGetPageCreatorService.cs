﻿using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Queries.GetAllPageCreator
{
    public interface IGetPageCreatorService
    {
        Task<ResultGetPageCreatorDto> Execute(RequestGetPageCreatorDto requestGetPage);
    }
    public class GetPageCreatorService : IGetPageCreatorService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _languege;
        public GetPageCreatorService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _configuration = configuration;
            _languege = languege;
        }
        public async Task<ResultGetPageCreatorDto> Execute(RequestGetPageCreatorDto requestGetPage)
        {
            string languageId = _languege.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultGetPageCreatorDto
                {
                   
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var PagesList = _context.PageCreators.Where(q => q.LanguageId == languageId).OrderByDescending(w => w.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(requestGetPage.SearchKey))
            {
                PagesList = PagesList.Where(l => l.Title.Contains(requestGetPage.SearchKey) || l.Description.Contains(requestGetPage.SearchKey));
            }
            int RowsCount = 0;
            var Pages =
             PagesList.Where(q => q.IsRemoved == false).Select(r => new GetAllPageCreatorDto
             {
                Id=r.Id,
                IsActive=r.IsActive,
                Title=r.Title,
                Url=BaseUrl+"/Pages/Detail/"+(string.IsNullOrEmpty(r.Slug)?r.Id:r.Slug.Replace(" ","-")),
             }).ToPaged(requestGetPage.Page, requestGetPage.PageSize, out RowsCount).ToList();
            return new ResultGetPageCreatorDto
            {
                PageCreators = Pages,
                Rows = RowsCount,
                Pageinate = Pagination.PaginateAdmin(requestGetPage.Page, requestGetPage.PageSize, RowsCount, "pages", requestGetPage.SearchKey, requestGetPage.Tag, requestGetPage.Category),
            };
        }
    }
    public class GetAllPageCreatorDto
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public bool IsActive { get; set; }
    }
    public class ResultGetPageCreatorDto
    {
        public List<GetAllPageCreatorDto> PageCreators { get; set; }
        public long Rows;
        public string? Pageinate { get; set; }
    }
    public class RequestGetPageCreatorDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchKey { get; set; }
        public string? Tag { get; set; }
        public string? Category { get; set; }
    }
}
