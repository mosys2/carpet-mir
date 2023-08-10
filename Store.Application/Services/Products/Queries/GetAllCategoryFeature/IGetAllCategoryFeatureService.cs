using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Queries.GetProductsList;
using Store.Application.Services.Sizes.Queries.GetAllSize;
using Store.Common.Constant.TypeOfCategoryFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Queries.GetAllCategoryFeature
{
    public interface IGetAllCategoryFeatureService
    {
        Task<List<GetAllCategoryFeatureDto>> Execute(string categoryId);
            
    }
    public class GetAllCategoryFeatureService : IGetAllCategoryFeatureService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllCategoryFeatureService(IDatabaseContext context,IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<List<GetAllCategoryFeatureDto>> Execute(string categoryId)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetAllCategoryFeatureDto>
                {
                };
            }
            var CategoryFeatureList = _context.Category.Where(q => q.LanguageId == languageId)
                   .Include(c => c.ItemSizes).ThenInclude(i => i.Size)
                   .Include(c => c.ItemColors).ThenInclude(i => i.Color)
                   .Include(c => c.ItemMaterials).ThenInclude(i => i.Material)
                   .Include(c => c.ItemShapes).ThenInclude(i => i.Shape)
                   .OrderByDescending(p => p.InsertTime).AsQueryable();

            var CategoryFeatures =
            await CategoryFeatureList.Where(q => q.IsRemoved == false && q.Id==categoryId).Select(r => new GetAllCategoryFeatureDto
            {
                Colors=r.ItemColors.Select(d=>new CategoryFeatureModel{ 
                Id=d.Color.Id,
                Name=d.Color.Name,
                Value=d.Color.Value,
                TypeOfCategoryFeature=TypeOfCategoryFeature.Color
                }).ToList(),
                Materials=r.ItemMaterials.Select(m => new CategoryFeatureModel{
                Id=m.Material.Id,
                Name=m.Material.Name,
                    TypeOfCategoryFeature = TypeOfCategoryFeature.Material
                }).ToList(),
                Shapes=r.ItemShapes.Select(p => new CategoryFeatureModel
                {
                    Id=p.Shape.Id,
                    Name =p.Shape.Name,
                    TypeOfCategoryFeature=TypeOfCategoryFeature.Shape
                }).ToList(),
                Sizes=r.ItemSizes.Select(p => new SizeModel
                {
                Lenght=p.Size.Lenght,
                Width=p.Size.Width,
                TypeOfCategoryFeature=TypeOfCategoryFeature.Size
                }).ToList(),
            }).ToListAsync();

            return CategoryFeatures;
        }
    }
    public class GetAllCategoryFeatureDto
    {
        public List<CategoryFeatureModel>? Colors { get; set; }
        public List<SizeModel>? Sizes { get; set; }
        public List<CategoryFeatureModel>? Materials { get; set; }
        public List<CategoryFeatureModel>? Shapes { get; set; }

    }
    public class SizeModel
    {
        public int? Width { get; set; }
        public int? Lenght { get; set; }
        public string TypeOfCategoryFeature { get; set; }

    }
    public class CategoryFeatureModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string TypeOfCategoryFeature { get; set; }

    }
}
