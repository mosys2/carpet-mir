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
        public async Task<IActionResult> Index(int page = 1,string? searchKey="",string? tag="",string? category="")
        {
            var setting = await _getSettingServices.Execute();
            var pagesize = setting.Data.ShowPerPage;
            ViewBag.Setting=setting.Data;
            var blogs =await _blogFacadSite.GetAllBlogSiteService.Execute(searchKey,page, pagesize,tag,category);
            if (blogs == null)
            {
                return Redirect("Home/NotFound");
            }
            return View(blogs.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(string Id)
        {
            var DetailBlog =await _blogFacadSite.GetDetailBlogSiteService.Execute(Id);
            if (DetailBlog.IsSuccess == false||DetailBlog.Data==null)
            {
                return Redirect("/Home/NotFound");
            }
            BlogDetailViewModel blogDetail = new BlogDetailViewModel
            {
                DetailBlog=DetailBlog.Data,
                Comment=new CommentBlogDto()
            };
            return View(blogDetail);
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
