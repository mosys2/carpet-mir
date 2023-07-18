using Store.Application.Services.Blogs.Commands.AddNewCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.ProductsSite.Commands.AddNewCategory;

namespace EndPointStore.Areas.Admin.Models.ViewModelCategoryBlog
{
    public class ViewModelCategoryBlog
    {
        public List<GetCategoryBlogDto> GetCategoryBlogs { get; set; }
        public RequestCategoryBlogDto RequestCategoryBlog { get; set; }
    }
}
