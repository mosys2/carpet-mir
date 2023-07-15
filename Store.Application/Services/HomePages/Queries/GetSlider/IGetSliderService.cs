using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant.NoImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePages.Queries.GetSlider
{
    public interface IGetSliderService
    {
        Task<List<ListSliderDto>> Execute();
    }
    public class GetSliderService : IGetSliderService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        public GetSliderService(IDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<List<ListSliderDto>> Execute()
        {
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var slider = _context.Sliders.Select(w => new ListSliderDto
            {
                Id = w.Id,
                Description = w.Description,
                Link = w.Link,
                IsActive=w.IsActive,
                Title = w.Title,
                UrlImage =BaseUrl+w.UrlImage,
                Url=w.UrlImage,
                InsertTime = w.InsertTime,

            }).ToList().OrderByDescending(d => d.InsertTime).ToList();
            return slider;
        }
    }
    public class ListSliderDto
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string? UrlImage { get; set; }
        public string? Url { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
