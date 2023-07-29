using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.SiteContacts.Queries.GetSocialMediaForSite;
using Store.Application.Services.UsersAddress.Queries.GetAddressUserForSite;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "SocialMedia")]
    public class SocialMedia:ViewComponent
    {
        private readonly IGetSocialMediaSiteService _getSocialMediaSiteService;
        public SocialMedia(IGetSocialMediaSiteService getSocialMediaSiteService)
        {
            _getSocialMediaSiteService = getSocialMediaSiteService;
        }
        public IViewComponentResult Invoke()
        {
            var SocialMediaList = _getSocialMediaSiteService.Execute();
            return View(viewName: "SocialMedia", SocialMediaList.Result);
        }
    }
}
