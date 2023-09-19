using Microsoft.AspNetCore.Mvc.Localization;
using Store.Application.Services.Blogs.Queries.GetLastedPostsForSite;

namespace EndPointStore.Models.LastedPostViewModel
{
    public class LastedPostViewModel
    {
        public LocalizedHtmlString Title { get; set; }
        public List<GetLastedPostsDto> LastedPosts { get; set; }
    }
}
