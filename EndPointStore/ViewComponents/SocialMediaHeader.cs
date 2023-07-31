using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "SocialMediaHeader")]
    public class SocialMediaHeader:ViewComponent
    {
        private readonly IGetSocialMediaSiteService _getSocialMediaSiteService;
        public SocialMediaHeader(IGetSocialMediaSiteService getSocialMediaSiteService)
        {
            _getSocialMediaSiteService = getSocialMediaSiteService;
        }
        public IViewComponentResult Invoke()
        {
            var SocialMediaList = _getSocialMediaSiteService.Execute();
            return View(viewName: "SocialMediaHeader", SocialMediaList.Result);
        }
    }
}
