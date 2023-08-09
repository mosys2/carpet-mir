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
            var Category =await _context.Category.FindAsync(featureToCatego.CategoryId);
            // Check Null
            if (Category == null)
            {
                return new ResultDto
                {
                    Message = MessageInUser.NotFind,
                    IsSuccess = false
                    
                };
            }
            //Check Exists
            var existingCategory = false; // نشانگر وجود دسته‌بندی با ترکیب مشخصه‌ها
            if (featureToCatego.SizeId != null && featureToCatego.ColorId != null && featureToCatego.MaterialId != null && featureToCatego.ShapeId != null)
            {
                foreach (var sizeId in featureToCatego.SizeId)
                {
                    foreach (var colorId in featureToCatego.ColorId)
                    {
                        foreach (var materialId in featureToCatego.MaterialId)
                        {
                            foreach (var shapeId in featureToCatego.ShapeId)
                            {
                                // بررسی وضعیت وجود دسته‌بندی با ترکیب مشخصه‌ها
                                if (_context.ItemSizes.Any(w => w.CategoryId == Category.Id && w.SizeId == sizeId) &&
                                    _context.ItemColors.Any(w => w.CategoryId == Category.Id && w.ColorId == colorId) &&
                                    _context.ItemMaterials.Any(w => w.CategoryId == Category.Id && w.MaterialId == materialId) &&
                                    _context.ItemShapes.Any(w => w.CategoryId == Category.Id && w.ShapeId == shapeId))
                                {
                                    existingCategory = true;
                                    break;
                                }
                            }
                            if (existingCategory)
                            {
                                break;
                            }
                        }
                        if (existingCategory)
                        {
                            break;
                        }
                    }
                    if (existingCategory)
                    {
                        return new ResultDto
                        {
                            Message = " تکراری است!",
                            IsSuccess = false
                        };
                    }
                }
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
                        Category= Category,
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
                Message =MessageInUser.MessageInsert,
                IsSuccess = true
            };
        }
    }
    public class AddNewFeatureToCategoryDto
    {
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
