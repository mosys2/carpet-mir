using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.OrderCarpet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.RegisterCustomCarpet
{
    public interface IRegisterCustomCarpetSiteService
    {
        Task<ResultDto> Execute(RegisterCustomCarpetDto registerCustom);

    }
    public class RegisterCustomCarpetSiteService : IRegisterCustomCarpetSiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public RegisterCustomCarpetSiteService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(RegisterCustomCarpetDto registerCustom)
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
            //Find Names Feature
            var categoryName = _context.Category.FindAsync(registerCustom.CategoryId).Result?.Name;
            var colorName =_context.Colors.FindAsync(registerCustom.ColorId).Result?.Name;
            if(colorName == null)
            {
                colorName = registerCustom.ColorId;
            }
            //var sizeName =await _context.Sizes.FindAsync(registerCustom.SizeId);
            var materialName = _context.Materials.FindAsync(registerCustom.MaterialId).Result?.Name;
            if(materialName==null)
            {
                materialName = registerCustom.MaterialId;
            }
            var shapeName = _context.Shapes.FindAsync(registerCustom.ShapeId).Result?.Name;
            if(shapeName==null)
            {
                shapeName = registerCustom.ShapeId;
            }
            //Add
            RegisterCarpet registerCarpet = new RegisterCarpet()
            {
                Id=Guid.NewGuid().ToString(),
                Name=registerCustom.Name,
                Address=registerCustom.Address,
                Email=registerCustom.Email,
                DeliveryDate = registerCustom.DeliveryDate,
                Color=colorName,
                Shape=shapeName,
                Material=materialName,
                Size=registerCustom.SizeId,
                Country=registerCustom.Country,
                PhoneNumber=registerCustom.PhoneNumber,
                LanguageId=languageId,
                CategoryId = registerCustom.CategoryId,
                CategoryName = categoryName,
                InsertTime=DateTime.Now,
                TypeName=registerCustom.TypeName
            };
            _context.RegisterCarpets.Add(registerCarpet);
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsertEn
            };
        }
    }
    public class RegisterCustomCarpetDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? ColorId { get; set; }
        public string? SizeId { get; set; }
        public string? MaterialId { get; set; }
        public string? ShapeId { get; set; }
        public string? CategoryId { get; set; }
        public string? TypeName { get; set; }
    }
}
