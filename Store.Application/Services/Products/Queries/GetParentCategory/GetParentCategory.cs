using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
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
        public GetParentCategory(IDatabaseContext context)
        {
            _context = context;
        }
        public static List<ParentCategoryDto> Category = new List<ParentCategoryDto>();
        public static List<ParentCategoryDto> AllCategory = new List<ParentCategoryDto>();
        public async Task<List<ParentCategoryDto>> Execute(string languageId)
        {
            Category.Clear();
            AllCategory.Clear();
            var categoryList = _context.Category.Include(p => p.Language).AsQueryable();
            if (!string.IsNullOrEmpty(languageId))
            {
                categoryList=categoryList.Where(p => p.LanguageId==languageId);
            }
            var listCategory = categoryList.Select
                (
                e => new ParentCategoryDto()
                {
                    Id = e.Id,
                    Name = e.Name,
                    ParentId = e.ParentCategoryId,
                    InsertTime = e.InsertTime,
                    IsActive = e.IsActive,
                    Slug = e.Slug,
                    Description = e.Description,
                    OrginallName = e.Name,
                    LanguegeId=e.LanguageId,
                    LanguegeName=e.Language.Name
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
                    LanguegeId=item.LanguegeId,
                    LanguegeName=item.LanguegeName
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
                        LanguegeId= itemChild.LanguegeId,
                        LanguegeName= itemChild.LanguegeName
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
                        LanguegeId = itemChild.LanguegeId,
                        LanguegeName = itemChild.LanguegeName
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

