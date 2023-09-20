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
using Size = Store.Domain.Entities.OrderCarpet.Size;

namespace Store.Application.Services.Sizes.Commands.AddNewSize
{
    public interface IAddNewSizeService
    {
        Task<ResultDto> Execute(AddNewSize addNewSize);
    }
    public class AddNewSizeService : IAddNewSizeService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewSizeService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(AddNewSize addNewSize)
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
            if (addNewSize.Id != null)
            {
                var resultEdit = await _context.Sizes.FindAsync(addNewSize.Id);
                resultEdit.Width = addNewSize.Width;
                resultEdit.Height = addNewSize.Height;
                resultEdit.Lenght = addNewSize.Lenght;
                resultEdit.UpdateTime = DateTime.Now;
                resultEdit.LanguageId= languageId;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = MessageInUser.MessageUpdate
                };
            }
            Size sizes = new Size()
            {
                Id = Guid.NewGuid().ToString(),
                Width = addNewSize.Width,
                Height = addNewSize.Height,
                Lenght = addNewSize.Lenght,
                LanguageId = languageId,
                InsertTime = DateTime.Now,
            };
            await _context.Sizes.AddAsync(sizes);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
    }
    public class AddNewSize
    {
        public string? Id { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Lenght { get; set; }

    }
}
