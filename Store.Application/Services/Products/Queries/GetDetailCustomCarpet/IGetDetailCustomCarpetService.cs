using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Queries.GetAllRegisterCustomCarpet;
using Store.Common;
using Store.Common.Constant.NoImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Queries.GetDetailCustomCarpet
{
    public interface IGetDetailCustomCarpetService
    {
        Task<GetDetailCustomCarpetDto> Execute(string Id);
    }
    public class GetDetailCustomCarpetService : IGetDetailCustomCarpetService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        private readonly IConfiguration _configuration;

        public GetDetailCustomCarpetService(IDatabaseContext context,
            IGetSelectedLanguageServices language,
            IConfiguration configuration)
        {
            _context = context;
            _language = language;
            _configuration=configuration;
        }
        public async Task<GetDetailCustomCarpetDto> Execute(string Id)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new GetDetailCustomCarpetDto
                {

                };
            }
            var RegisterCustom = await _context.RegisterCarpets
                .Where(w => w.LanguageId == languageId && w.IsRemoved == false && w.Id == Id)
                .FirstOrDefaultAsync();
            if (RegisterCustom == null)
            {

                return new GetDetailCustomCarpetDto
                {

                };
            }
            RegisterCustom.Seen = true;
            await _context.SaveChangesAsync();

            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            return new GetDetailCustomCarpetDto
            {
                Name = RegisterCustom.Name,
                Country = RegisterCustom.Country,
                InsertTime = Assistants.ConvertToShamsi(RegisterCustom.InsertTime.Value.ToString()),
                Seen = RegisterCustom.Seen,
                Address = RegisterCustom.Address,
                CategoryName = RegisterCustom.CategoryName,
                ColorName = RegisterCustom.Color,
                DeliveryDate =string.IsNullOrEmpty(RegisterCustom.DeliveryDate?.ToString())?"":Assistants.ConvertToShamsi(RegisterCustom.DeliveryDate.Value.ToString()),
                Email = RegisterCustom.Email,
                MaterialName = RegisterCustom.Material,
                PhoneNumber = RegisterCustom.PhoneNumber,
                ShapeName = RegisterCustom.Shape,
                SizeName = RegisterCustom.Size,
                TypeName = RegisterCustom.TypeName,
                Image = string.IsNullOrEmpty(RegisterCustom.Image) ? ImageProductConst.NoImage: BaseUrl + "/UserUploads/" +RegisterCustom.Image,
                Description=RegisterCustom.Description
            };
        }
    }
    public class GetDetailCustomCarpetDto
    {
        public string? Name { get; set; }
        public bool Seen { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string InsertTime { get; set; }
        public string? Address { get; set; }
        public string? DeliveryDate { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public string? MaterialName { get; set; }
        public string? ShapeName { get; set; }
        public string? CategoryName { get; set; }
        public string? TypeName { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
