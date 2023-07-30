using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "SocialMediaFooter")]
    public class SocialMediaFooter:ViewComponent
    {
        private readonly IGetSocialMediaSiteService _getSocialMediaSiteService;
        public SocialMediaFooter(IGetSocialMediaSiteService getSocialMediaSiteService)
        {
            _getSocialMediaSiteService = getSocialMediaSiteService;
        }
        public IViewComponentResult Invoke()
        {
            var SocialMediaList = _getSocialMediaSiteService.Execute();
            return View(viewName: "SocialMediaFooter", SocialMediaList.Result);
        }
    }
}
