using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Constant.NoImage;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetParentCategory
{
    public class GetParentCategory : IGetParentCategory
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        private readonly IConfiguration _configuration;

        public GetParentCategory(IDatabaseContext context,
            IGetSelectedLanguageServices language, IConfiguration configuration)
        {
            _context = context;
            _language = language;
            _configuration = configuration;
        }
        public static List<ParentCategoryDto> Category = new List<ParentCategoryDto>();
        public static List<ParentCategoryDto> AllCategory = new List<ParentCategoryDto>();
        string BaseUrl2 = "";
        public async Task<List<ParentCategoryDto>> Execute()
        {
            Category.Clear();
            AllCategory.Clear();

            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<ParentCategoryDto>
                {
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            BaseUrl2 = BaseUrl;
            var listCategory = _context.Category.Where(p => p.LanguageId==languageId)
             .Select(e => new ParentCategoryDto()
             {
                 Id = e.Id,
                 Name = e.Name,
                 ParentId = e.ParentCategoryId,
                 InsertTime = e.InsertTime,
                 IsActive = e.IsActive,
                 Slug = e.Slug,
                 Description = e.Description,
                 OrginallName = e.Name,
                 Image=e.Icon
             }
             ).OrderByDescending(p => p.InsertTime).ToList();

            AllCategory.AddRange(listCategory);

            foreach (var item in listCategory.Where(e => e.ParentId == null))
            {
                int level = 1;
                Category.Add(new ParentCategoryDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId,
                    ParentName = "اصلی",
                    IsActive = item.IsActive,
                    Slug = item.Slug,
                    Description = item.Description,
                    OrginallName = item.Name,
                    Url=item.Image,
                    Image = !string.IsNullOrEmpty(item.Image) ? BaseUrl + item.Image : ImageProductConst.NoImage,
                });
                var child = listCategory.Where(y => y.ParentId == item.Id).ToList();
                listGenerator(child, level);
            }
            return Category;
        }
        public void listGenerator(List<ParentCategoryDto> selectList, int level)
        {
            level++;
            foreach (var itemChild in selectList)
            {
                var childN = AllCategory.Where(p => p.ParentId == itemChild.Id).ToList();
                if (childN.Any())
                {
                    Category.Add(new ParentCategoryDto()

                    {
                        Id = itemChild.Id,
                        Name = GetDashCount(level) + " " + itemChild.Name,
                        ParentId = itemChild.ParentId,
                        ParentName = AllCategory.Where(t => t.Id == itemChild.ParentId).FirstOrDefault()?.Name,
                        IsActive = itemChild.IsActive,
                        Slug = itemChild.Slug,
                        Description = itemChild.Description,
                        OrginallName = itemChild.Name,
                        Url=itemChild.Image,
                        Image = !string.IsNullOrEmpty(itemChild.Image) ? BaseUrl2 + itemChild.Image : ImageProductConst.NoImage,
                    });
                    listGenerator(childN, level);
                }
                else
                {
                    Category.Add(new ParentCategoryDto()
                    {
                        Id = itemChild.Id,
                        Name = GetDashCount(level) + " " + itemChild.Name,
                        ParentId = itemChild.ParentId,
                        ParentName = AllCategory.Where(t => t.Id == itemChild.ParentId).FirstOrDefault()?.Name,
                        IsActive = itemChild.IsActive,
                        Slug = itemChild.Slug,
                        Description = itemChild.Description,
                        OrginallName = itemChild.Name,
                        Url = itemChild.Image,
                        Image = !string.IsNullOrEmpty(itemChild.Image) ? BaseUrl2 + itemChild.Image : ImageProductConst.NoImage,
                    });
                }
            }
            return;
        }
        public string GetDashCount(int level)
        {
            string dash = "";
            for (int i = 1; i < level; i++)
            {
                dash += "- ";
            }
            return dash;
        }

    }

}

