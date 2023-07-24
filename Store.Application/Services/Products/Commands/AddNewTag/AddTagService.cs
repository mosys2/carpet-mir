using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Commands.AddNewTag
{
    public class AddTagService : IAddTagService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddTagService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(string name)
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
            var cheackTag = _context.Tags.Where(n => n.Name == name).FirstOrDefault();
            if (cheackTag != null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.ExistTag
                };
            }
            Tag tag = new Tag()
            {

                Id = Guid.NewGuid().ToString(),
                Name = name,
                InsertTime = DateTime.Now,
                LanguageId=languageId
                
            };
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "موفق"
            };
        }
    }
}
