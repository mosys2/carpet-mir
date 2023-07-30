using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.SettingsSite.Queries;

namespace EndPointStore.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogFacadSite _blogFacadSite;
        private readonly IGetSettingServices _getSettingServices;
        public BlogsController(IBlogFacadSite blogFacadSite, IGetSettingServices getSettingServices)
        {
            _blogFacadSite = blogFacadSite;
            _getSettingServices = getSettingServices;
        }
        public async Task<IActionResult> Index(string? searchKey,int page=1)
        {
            var pagesize =_getSettingServices.Execute().Result.Data.ShowPerPage;
            var blogs =await _blogFacadSite.GetAllBlogSiteService.Execute(searchKey,page, pagesize);
            return View(blogs.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(string Id)
        {
            var DetailBlog =await _blogFacadSite.GetDetailBlogSiteService.Execute(Id);
            return View(DetailBlog.Data);
        }
        [HttpGet]
        public IActionResult RelatedPostViewComponent(string Id)
        {
            return ViewComponent("RelatedPost", Id);
        }
    }
}
