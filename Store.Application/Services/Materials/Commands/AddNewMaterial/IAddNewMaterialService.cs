using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Colors.Commands.AddNewColor;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.OrderCarpet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Materials.Commands.AddNewMaterial
{
    public interface IAddNewMaterialService
    {
        Task<ResultDto> Execute(AddNewMaterial newMaterial);

    }
    public class AddNewMaterialService : IAddNewMaterialService
    {

        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewMaterialService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(AddNewMaterial newMaterial)
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
            if (newMaterial.Id != null)
            {
                var resultEdit = await _context.Materials.FindAsync(newMaterial.Id);
                resultEdit.Name = newMaterial.Name;
                resultEdit.UpdateTime = DateTime.Now;
                resultEdit.LanguageId = languageId;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageUpdate
                };
            }
            Material materials = new Material()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newMaterial.Name,
                LanguageId = languageId,
                InsertTime = DateTime.Now,
            };
            await _context.Materials.AddAsync(materials);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class AddNewMaterial
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
