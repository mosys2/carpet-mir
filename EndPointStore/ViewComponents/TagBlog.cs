using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPatternSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "TagBlog")]
    public class TagBlog:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        public TagBlog(IBlogFacadSite blogFacadSite)
        {
            _blogFacadSite = blogFacadSite;
        }
        public IViewComponentResult Invoke()
        {
            var tags = _blogFacadSite.GetTagBlogSiteService.Execute();
            return View(viewName: "TagBlog", tags.Result);
        }
    }
}
