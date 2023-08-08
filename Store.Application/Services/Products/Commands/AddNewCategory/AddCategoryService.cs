using Microsoft.CodeAnalysis.CSharp.Syntax;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.AddNewCategory
{
    public class AddCategoryService : IAddCategory
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddCategoryService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(RequestCatgoryDto requestCatgoryDto)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess=false,
                    Message=MessageInUser.NotFind
                };
            }
            //Check Edit Or Create
            if (requestCatgoryDto.Id != null)
            {

                var EditList = await _context.Category.FindAsync(requestCatgoryDto.Id);
                EditList.Name = requestCatgoryDto.Name;
                EditList.Slug = requestCatgoryDto.Slug;
                EditList.IsActive = requestCatgoryDto.IsActive;
                EditList.ParentCategoryId = requestCatgoryDto.ParentId;
                EditList.Description = requestCatgoryDto.Description;
                EditList.Icon = requestCatgoryDto.Icon;
                EditList.LanguageId = languageId;
                EditList.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                Category categories = new Category()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = requestCatgoryDto.Name,
                    Description = requestCatgoryDto.Description,
                    CssClass = requestCatgoryDto.CssClass,
                    Slug = requestCatgoryDto.Slug,
                    IsActive = requestCatgoryDto.IsActive,
                    Icon = requestCatgoryDto.Icon,
                    Sort = requestCatgoryDto.Sort,
                    InsertTime = DateTime.Now,
                    LanguageId= languageId,
                    ParentCategory = GetCategories(requestCatgoryDto.ParentId),
                };
                //Add Category
                _context.Category.Add(categories);
                _context.SaveChanges();
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
        private Category GetCategories(string? ParentId)
        {
            return _context.Category.Find(ParentId);
        }
    }
}
