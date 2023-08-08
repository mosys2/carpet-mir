using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Authors;
using Store.Domain.Entities.OrderCarpet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Colors.Commands.AddNewColor
{
    public interface IAddNewColorService
    {
        Task<ResultDto> Execute(AddNewColor addNewColor);
    }
    public class AddNewColorService : IAddNewColorService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewColorService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(AddNewColor addNewColor)
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
            if (addNewColor.Id != null)
            {
                var resultEdit = await _context.Colors.FindAsync(addNewColor.Id);
                resultEdit.Name = addNewColor.Name;
                resultEdit.Value = addNewColor.Value;
                resultEdit.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageInsert
                };
            }
            Color colors = new Color()
            {
                Id = Guid.NewGuid().ToString(),
                Name = addNewColor.Name,
                Value=addNewColor.Value,
                LanguageId = languageId,
                InsertTime = DateTime.Now,
            };
            await _context.Colors.AddAsync(colors);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class AddNewColor
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}
