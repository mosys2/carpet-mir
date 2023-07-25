using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.HomePages;
using Store.Domain.Entities.Results;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Results.Commands.AddNewResult
{
    public interface IAddNewResultService
    {
        Task<ResultDto> Execute(RequstResultDto requstResult);
    }
    public class AddNewResultService : IAddNewResultService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public AddNewResultService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute(RequstResultDto requstResult)
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
            if (requstResult.Id != null)
            {
                var resultEdit = await _context.Results.FindAsync(requstResult.Id);
                resultEdit.Title = requstResult.Title;
                resultEdit.Value = requstResult.Value;
                resultEdit.Image = requstResult.Image;
                resultEdit.IsActive = requstResult.IsActive;
                resultEdit.CssClass = requstResult.CssClass;
                resultEdit.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "موفق"
                };
            }
            Result result = new Result()
            {
                Id = Guid.NewGuid().ToString(),
                Title = requstResult.Title,
                Value = requstResult.Value,
                CssClass = requstResult.CssClass,
                IsActive = requstResult.IsActive,
                Image = requstResult.Image,
                InsertTime = DateTime.Now,
                LanguageId =languageId,
            };
            _context.Results.Add(result);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "موفق"
            };
        }
    }
    public class RequstResultDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }
        public string? CssClass { get; set; }
    }
}
