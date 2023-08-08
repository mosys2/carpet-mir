using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "SocialMediaInBlogDetail")]
    public class SocialMediaInBlogDetail:ViewComponent
    {
        private readonly IGetSocialMediaSiteService _getSocialMediaSiteService;
        public SocialMediaInBlogDetail(IGetSocialMediaSiteService getSocialMediaSiteService)
        {
            _getSocialMediaSiteService = getSocialMediaSiteService;
        }
        public IViewComponentResult Invoke()
        {
            var SocialMediaList = _getSocialMediaSiteService.Execute();
            return View(viewName: "SocialMediaInBlogDetail", SocialMediaList.Result);
        }
    }
}
