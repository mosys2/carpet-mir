using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Common.Constant.NoImage;
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
        public GetResultService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<List<ListResultDto>> Execute()
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var result = _context.Results.Select(w => new ListResultDto
            {
                Id = w.Id,
                Value = w.Value,
                CssClass = w.CssClass,
                IsActive = w.IsActive,
                Title = w.Title,
                UrlImage = string.IsNullOrEmpty(w.Image) ? ImageProductConst.NoImage:BaseUrl + w.Image,
                Url = w.Image,
                InsertTime = w.InsertTime,

            }).ToList().OrderByDescending(d => d.InsertTime).ToList();
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
