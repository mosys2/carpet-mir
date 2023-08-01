using EndPointStore.Models.BlogDetailViewModel;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces.FacadPatternSite;
using Store.Application.Services.Blogs.Commands.AddNewComment;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

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
        [HttpGet]
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
            BlogDetailViewModel blogDetail = new BlogDetailViewModel
            {
                DetailBlog=DetailBlog.Data,
                Comment=new CommentBlogDto()
            };
            return View(blogDetail);
        }
        [HttpGet]
        public IActionResult RelatedPostViewComponent(string Id)
        {
            return ViewComponent("RelatedPost", Id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentBlogDto model)
        {
            if(!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess=false,
                    Message=MessageInUser.InvalidFormEn
                });
            }
            var result= await _blogFacadSite.AddCommentBlogService.Execute(model);
            return Json(result);
        }
    }
    //public class CommentBlogModel
    //{
    //    public string BlogId { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public string? Website { get; set; }
    //    public string Content { get; set; }
    //    public string? ParentCommentId { get; set; }
    //}
}
