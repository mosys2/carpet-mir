using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Materials.Commands.AddNewMaterial;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.OrderCarpet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Shapes.Commands.AddNewShape
{
    public interface IAddNewShapeService
    {
        Task<ResultDto> Execute(AddNewShape newShape);

    }
    public class AddNewShapeService : IAddNewShapeService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewShapeService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(AddNewShape newShape)
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
            if (newShape.Id != null)
            {
                var resultEdit = await _context.Shapes.FindAsync(newShape.Id);
                resultEdit.Name = newShape.Name;
                resultEdit.UpdateTime = DateTime.Now;
                resultEdit.LanguageId = languageId;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageUpdate
                };
            }
            Shape shapes = new Shape()
            {
                Id = Guid.NewGuid().ToString(),
                Name = newShape.Name,
                LanguageId = languageId,
                InsertTime = DateTime.Now,
            };
            await _context.Shapes.AddAsync(shapes);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class AddNewShape
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
