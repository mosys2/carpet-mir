using Store.Application.Services.Blogs.Commands.AddNewComment;
using Store.Application.Services.Blogs.Queries.GetDetailBlogForSite;

namespace EndPointStore.Models.BlogDetailViewModel
{
    public class BlogDetailViewModel
    {
        public GetDetailBlogSiteDto? DetailBlog { get; set; }
        public CommentBlogDto Comment { get; set; }
    }
}
