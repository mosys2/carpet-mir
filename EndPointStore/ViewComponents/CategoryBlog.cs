using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPatternSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "CategoryBlog")]
    public class CategoryBlog:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        public CategoryBlog(IBlogFacadSite blogFacadSite)
        {
            _blogFacadSite = blogFacadSite; 
        }
        public IViewComponentResult Invoke()
        {
            var category = _blogFacadSite.GetCategoryBlogSiteService.Execute();
            return View(viewName: "CategoryBlog", category.Result);
        }
    }
}
