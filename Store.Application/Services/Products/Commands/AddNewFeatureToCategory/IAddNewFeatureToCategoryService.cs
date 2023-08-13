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
            //List<string> sizeIds = featureToCatego.SizeId?.ToList() ?? new List<string>();
            //List<string> colorIds = featureToCatego.ColorId?.ToList() ?? new List<string>();
            //List<string> materialIds = featureToCatego.MaterialId?.ToList() ?? new List<string>();
            //List<string> shapeIds = featureToCatego.ShapeId?.ToList() ?? new List<string>();
            var sizeIdsInCategory = Category.ItemSizes.Where(u => u.SizeId == featureToCatego.SizeId).Any();
            var colorIdsInCategory = Category.ItemColors.Where(u => u.ColorId == featureToCatego.ColorId).Any();
            var materialIdsInCategory = Category.ItemMaterials.Where(i => i.MaterialId==featureToCatego.MaterialId).Any();
            var shapeIdsInCategory = Category.ItemShapes.Where(i => i.ShapeId==featureToCatego.ShapeId).Any();
            //Check Exists

            //{
            //    if(sizeIdsInCategory.All(sizeId => sizeIds.Contains(sizeId)))
            //    {
            //        return new ResultDto
            //        {
            //            Message = MessageInUser.MessageExistSize,
            //            IsSuccess = false
            //        };
            //    }
            //    if (colorIdsInCategory.All(colorId => colorIds.Contains(colorId)))
            //    {
            //        return new ResultDto
            //        {
            //            Message = MessageInUser.MessageExistColor,
            //            IsSuccess = false
            //        };
            //    }
            //    if (materialIdsInCategory.All(materialId => materialIds.Contains(materialId)))
            //    {
            //        return new ResultDto
            //        {
            //            Message = MessageInUser.MessageExistMaterial,
            //            IsSuccess = false
            //        };
            //    }
            //    if (shapeIdsInCategory.All(shapeId => shapeIds.Contains(shapeId)))
            //    {
            //        return new ResultDto
            //        {
            //            Message = MessageInUser.MessageExistShape,
            //            IsSuccess = false
            //        };
            //    } 
                if(sizeIdsInCategory&&shapeIdsInCategory&&materialIdsInCategory&&colorIdsInCategory)
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
                ItemSize itemSize = new ItemSize()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = featureToCatego.CategoryId,
                    ColorId = featureToCatego.ColorId,
                    MaterialId = featureToCatego.MaterialId,
                    ShapeId = featureToCatego.ShapeId,
                    SizeId = featureToCatego.SizeId,
                    InsertTime = DateTime.Now,
                };
                //List<ItemSize> itemSize = new List<ItemSize>();
                //foreach (var id in featureToCatego.SizeId)
                //{
                //    var Size = _context.Sizes.Find(id);
                //    itemSize.Add(new ItemSize
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Category=Category,
                //        CategoryId = Category.Id,
                //        Size=Size,

                //        SizeId = Size.Id,
                //        InsertTime = DateTime.Now,
                //    });
                //}
                //Add Item Size
                _context.ItemSizes.Add(itemSize);
               await _context.SaveChangesAsync();
            }
            //Find Item Color
            if (featureToCatego.ColorId != null)
            {
                ItemColor itemColor = new ItemColor()
                {
                    Id=Guid.NewGuid().ToString(),
                    CategoryId=featureToCatego.CategoryId,
                    ColorId=featureToCatego.ColorId,
                    MaterialId=featureToCatego.MaterialId,
                    ShapeId = featureToCatego.ShapeId,
                    SizeId = featureToCatego.SizeId,
                    InsertTime=DateTime.Now,
                };
                //List<ItemColor> itemColor = new List<ItemColor>();
                //foreach (var id in featureToCatego.ColorId)
                //{
                //    var Color = _context.Colors.Find(id);
                //   itemColor.Add(new ItemColor
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Category=Category,
                //        CategoryId = Category.Id,
                //        Color=Color,
                //        ColorId = Color.Id,
                //        InsertTime = DateTime.Now,
                //    });
                  
                //}
                //Add Item Color
                _context.ItemColors.Add(itemColor);
                await _context.SaveChangesAsync();
            }
            //Find Item Material
            if (featureToCatego.MaterialId != null)
            {
                ItemMaterial itemMaterial = new ItemMaterial()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = featureToCatego.CategoryId,
                    ColorId = featureToCatego.ColorId,
                    MaterialId = featureToCatego.MaterialId,
                    ShapeId = featureToCatego.ShapeId,
                    SizeId = featureToCatego.SizeId,
                    InsertTime = DateTime.Now,
                };
                //List<ItemMaterial> itemMaterial = new List<ItemMaterial>();
                //foreach (var id in featureToCatego.MaterialId)
                //{
                //    var Material = _context.Materials.Find(id);
                //     itemMaterial.Add(new ItemMaterial
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Category=Category,
                //        CategoryId = Category.Id,
                //        Material=Material,
                //        MaterialId = Material.Id,
                //        InsertTime = DateTime.Now,
                //    });
                //}
                //Add Item Material
                _context.ItemMaterials.Add(itemMaterial);
                await _context.SaveChangesAsync();
            }
            //Find Item Shape
            if (featureToCatego.ShapeId != null)
            {
                ItemShape itemShape = new ItemShape()
                {
                    Id = Guid.NewGuid().ToString(),
                    CategoryId = featureToCatego.CategoryId,
                    ColorId = featureToCatego.ColorId,
                    MaterialId = featureToCatego.MaterialId,
                    ShapeId = featureToCatego.ShapeId,
                    SizeId = featureToCatego.SizeId,
                    InsertTime = DateTime.Now,
                };
                //List<ItemShape> itemShape = new List<ItemShape>();
                //foreach (var id in featureToCatego.ShapeId)
                //{
                //   var Shape = _context.Shapes.Find(id);
                //   itemShape.Add(new ItemShape
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Category=Category,
                //        CategoryId = Category.Id,
                //        Shape=Shape,
                //        ShapeId = Shape.Id,
                //        InsertTime = DateTime.Now,
                //    });  
                //}
                //Add Item Shape
                _context.ItemShapes.Add(itemShape);
                await _context.SaveChangesAsync();
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
        [Required]
        public string ShapeId { get; set; }
        [Required]
        public string SizeId { get; set; }
        [Required]
        public string MaterialId { get; set; }
        [Required]
        public string ColorId { get; set; }
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
