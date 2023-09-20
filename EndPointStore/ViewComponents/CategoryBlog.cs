using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Store.Application.Interfaces.FacadPatternSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "CategoryBlog")]
    public class CategoryBlog:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        private readonly IStringLocalizer _localizer;
        public CategoryBlog(IBlogFacadSite blogFacadSite, IStringLocalizerFactory localizedFactory)
        {
            _blogFacadSite = blogFacadSite;
            _localizer = localizedFactory.Create("CategoryBlog", "EndPointStore");
        }
        public IViewComponentResult Invoke()
        {
            var category = _blogFacadSite.GetCategoryBlogSiteService.Execute();
            ViewBag.StringLocalizer = _localizer;
            return View(viewName: "CategoryBlog", category.Result);
        }
    }
}
