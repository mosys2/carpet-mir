using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Constant.NoImage;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Results.Queries.GetResult
{
    public interface IGetResultService
    {
        Task<List<ListResultDto>> Execute();

    }
    public class GetResultService : IGetResultService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetResultService(IDatabaseContext context, IConfiguration configuration, IGetSelectedLanguageServices language)
        {
            _context = context;
            _configuration = configuration;
            _language = language;
        }
        public async Task<List<ListResultDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<ListResultDto>
                {
                    
                };
            }
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var result =await _context.Results.Where(q => q.LanguageId == languageId).OrderByDescending(d => d.InsertTime).Select(w => new ListResultDto
            {
                Id = w.Id,
                Value = w.Value,
                CssClass = w.CssClass,
                IsActive = w.IsActive,
                Title = w.Title,
                UrlImage = string.IsNullOrEmpty(w.Image) ? ImageProductConst.NoImage:BaseUrl + w.Image,
                Url = w.Image,
                InsertTime = w.InsertTime,
            }).ToListAsync();
            return result;
        }
    }
    public class ListResultDto
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Value { get; set; }
        public bool IsActive { get; set; }
        public string? CssClass { get; set; }
        public string? UrlImage { get; set; }
        public string? Url { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
