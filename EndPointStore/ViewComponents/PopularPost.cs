using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPatternSite;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "PopularPost")]
    public class PopularPost:ViewComponent
    {
        private readonly IBlogFacadSite _blogFacadSite;
        public PopularPost(IBlogFacadSite blogFacadSite)
        {
            _blogFacadSite = blogFacadSite;
        }
        public IViewComponentResult Invoke()
        {
            var popularPost = _blogFacadSite.GetPopularPostsSiteService.Execute();
            return View(viewName: "PopularPost", popularPost.Result);
        }
    }
}
