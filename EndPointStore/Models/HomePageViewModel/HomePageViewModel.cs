using Store.Application.Services.Blogs.Queries.GetAllBlogForSite;
using Store.Application.Services.HomePages.Queries.GetSliderForSite;
using Store.Application.Services.ProductsSite.Queries.GetCategoryForSite;
using Store.Application.Services.Results.Queries.GetResultsForSite;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;
using Store.Common.Dto;

namespace EndPointStore.Models.HomePageViewModel
{
    public class HomePageViewModel
    {
        public List<GetSliderForSiteDto> GetSliderForSites { get; set; }
        public List<CategorySiteDto> CategorySites { get; set; }
        public List<GetResultSiteDto> GetResultSites { get; set; }
        public ResultDto<ResultBlogsForSiteDto> GetAllBlogSites { get; set; }
    }
}
