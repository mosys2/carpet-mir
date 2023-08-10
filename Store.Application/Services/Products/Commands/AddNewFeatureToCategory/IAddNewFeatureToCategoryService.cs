using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.OrderCarpet;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.AddNewFeatureToCategory
{
    public interface IAddNewFeatureToCategoryService
    {
        Task<ResultDto> Execute(AddNewFeatureToCategoryDto featureToCatego);
    }
    public class AddNewFeatureToCategoryService : IAddNewFeatureToCategoryService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddNewFeatureToCategoryService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(AddNewFeatureToCategoryDto featureToCatego)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            //Find Id
            var Category =await _context.Category
                   .Where(r => r.Id == featureToCatego.CategoryId)
                   .Include(c => c.ItemSizes).ThenInclude(i => i.Size)
                   .Include(c => c.ItemColors).ThenInclude(i => i.Color)
                   .Include(c => c.ItemMaterials).ThenInclude(i => i.Material)
                   .Include(c=>c.ItemShapes).ThenInclude(i=>i.Shape)
                   .FirstOrDefaultAsync();
            // Check Null
            if (Category == null)
            {
                return new ResultDto
                {
                    Message = MessageInUser.NotFind,
                    IsSuccess = false

                };
            }
            //Create List Ids
            List<string> sizeIds = featureToCatego.SizeId?.ToList() ?? new List<string>();
            List<string> colorIds = featureToCatego.ColorId?.ToList() ?? new List<string>();
            List<string> materialIds = featureToCatego.MaterialId?.ToList() ?? new List<string>();
            List<string> shapeIds = featureToCatego.ShapeId?.ToList() ?? new List<string>();
            var existingCombination = false;
            var sizeIdsInCategory = Category.ItemSizes.Select(i => i.Size.Id).ToList();
            var colorIdsInCategory = Category.ItemColors.Select(i => i.Color.Id).ToList();
            var materialIdsInCategory = Category.ItemMaterials.Select(i => i.Material.Id).ToList();
            var shapeIdsInCategory = Category.ItemShapes.Select(i => i.Shape.Id).ToList();
            //Check Exists
            if (sizeIdsInCategory.Count > 0|| colorIdsInCategory.Count>0|| materialIdsInCategory.Count>0|| shapeIdsInCategory.Count > 0)
            {
                if (sizeIdsInCategory.All(sizeId => sizeIds.Contains(sizeId)) &&
                    colorIdsInCategory.All(colorId => colorIds.Contains(colorId)) &&
                    materialIdsInCategory.All(materialId => materialIds.Contains(materialId)) &&
                    shapeIdsInCategory.All(shapeId => shapeIds.Contains(shapeId)))
                {
                    existingCombination = true;
                }
            }
            if (existingCombination)
            {
                return new ResultDto
                {
                    Message = MessageInUser.MessageExistsCategoryFeature,
                    IsSuccess = false
                };
            }
            //Find Item Size
            if (featureToCatego.SizeId != null)
            {
                List<ItemSize> itemSize = new List<ItemSize>();
                foreach (var id in featureToCatego.SizeId)
                {
                    var Size = _context.Sizes.Find(id);
                    itemSize.Add(new ItemSize
                    {
                        Id = Guid.NewGuid().ToString(),
                        Category = Category,
                        CategoryId = Category.Id,
                        Size = Size,
                        SizeId = Size.Id,
                        InsertTime = DateTime.Now,
                    });
                }
                //Add Item Size
                Category.ItemSizes = itemSize;
                _context.SaveChanges();
            }
            //Find Item Color
            if (featureToCatego.ColorId != null)
            {
                List<ItemColor> itemColor = new List<ItemColor>();
                foreach (var id in featureToCatego.ColorId)
                {
                    var Color = _context.Colors.Find(id);
                    itemColor.Add(new ItemColor
                    {
                        Id = Guid.NewGuid().ToString(),
                        Category = Category,
                        CategoryId = Category.Id,
                        Color = Color,
                        ColorId = Color.Id,
                        InsertTime = DateTime.Now,
                    });
                }
                //Add Item Color
                Category.ItemColors = itemColor;
                _context.SaveChanges();
            }
            //Find Item Material
            if (featureToCatego.MaterialId != null)
            {
                List<ItemMaterial> itemMaterial = new List<ItemMaterial>();
                foreach (var id in featureToCatego.MaterialId)
                {
                    var Material = _context.Materials.Find(id);
                    itemMaterial.Add(new ItemMaterial
                    {
                        Id = Guid.NewGuid().ToString(),
                        Category = Category,
                        CategoryId = Category.Id,
                        Material = Material,
                        MaterialId = Material.Id,
                        InsertTime = DateTime.Now,
                    });
                }
                //Add Item Material
                Category.ItemMaterials = itemMaterial;
                _context.SaveChanges();
            }
            //Find Item Shape
            if (featureToCatego.ShapeId != null)
            {
                List<ItemShape> itemShape = new List<ItemShape>();
                foreach (var id in featureToCatego.ShapeId)
                {
                    var Shape = _context.Shapes.Find(id);
                    itemShape.Add(new ItemShape
                    {
                        Id = Guid.NewGuid().ToString(),
                        Category = Category,
                        CategoryId = Category.Id,
                        Shape = Shape,
                        ShapeId = Shape.Id,
                        InsertTime = DateTime.Now,
                    });
                }
                //Add Item Shape
                Category.ItemShapes = itemShape;
                _context.SaveChanges();
            }
            return new ResultDto
            {
                Message = MessageInUser.MessageInsert,
                IsSuccess = true
            };
        }
    }
    public class AddNewFeatureToCategoryDto
    {
        [Required]
        public string CategoryId { get; set; }
        public string[]? ShapeId { get; set; }
        public string[]? SizeId { get; set; }
        public string[]? MaterialId { get; set; }
        public string[]? ColorId { get; set; }
    }
    public class AddNewFeatureToCategoryModel
    {
        [Required]
        public string Id { get; set; }
        public string? ShapeId { get; set; }
        public string? SizeId { get; set; }
        public string? MaterialId { get; set; }
        public string? ColorId { get; set; }
    }
}
