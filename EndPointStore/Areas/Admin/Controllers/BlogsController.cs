using EndPointStore.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Blogs.Commands.AddNewBlog;
using Store.Application.Services.Blogs.Commands.AddNewBlogTag;
using Store.Application.Services.Blogs.Commands.EditBlog;
using Store.Application.Services.Blogs.Commands.RemoveBlog;
using Store.Application.Services.Blogs.Queries.GetAllBlog;
using Store.Application.Services.Blogs.Queries.GetAllCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetEditBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogsController : Controller
	{
		private readonly IBlogFacad _blogFacad;
        private readonly IGetSettingServices _getSettingServices;
        public BlogsController(IBlogFacad blogFacad, IGetSettingServices getSettingServices)
        {
			_blogFacad=blogFacad;
			_getSettingServices=getSettingServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchkey, int page = 1)
		{
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var blogList =await _blogFacad.GetAllBlogService.Execute(new RequestGetBlogDto{
			Page=page,
			SearchKey=searchkey,
			PageSize=pagesize,
			Category=null,
			Tag=null
			});
			return View(blogList);
		}
		[HttpPost]
        public async Task<IActionResult> CreateBlogTag(BlogTagDto blog)
        {
			var result=await _blogFacad.AddNewBlogTagService.Execute(new BlogTagDto{
			Name=blog.Name,
			});
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogTagList()
        {
			var result = await _blogFacad.GetListBlogTagService.Execute();
            return Json(result);
        }
        [HttpGet]
		public async Task<IActionResult> Create()
		{
            ViewBag.AllAuthor = new SelectList(_blogFacad.GetAllAuthorService.Execute().Result.Data, "Id", "Name");
            ViewBag.AllBlogTag= new SelectList( _blogFacad.GetListBlogTagService.Execute().Result, "Id", "Name");
            ViewBag.AllCategoryBlog =new SelectList(_blogFacad.GetAllCategoryBlogService.Execute().Result.Data, "Id", "Name");
            return View();
		}
        [HttpPost]
        public async Task<IActionResult> Create(AddNewBlogModel blogModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
			var userId = ClaimUtility.GetUserId(User);
			if (userId == null)
			{
				return Json(new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.MessageUserNotLogin
				});
			}
			var result =await _blogFacad.AddNewBlogService.Execute(new RequestBlogDto
			{
				Title=blogModel.Title,
				Image=blogModel.Image,
                MinPic=blogModel.MinPic,
				ShowAt=blogModel.ShowAt,
				BlogTags=blogModel.BlogTags,
				CategoryBlogId=blogModel.CategoryBlog,
                KeyWords=blogModel.KeyWords,
                MetaTag=blogModel.MetaTag,
                Slug=blogModel.Slug,
				Content=blogModel.Content,
				WriterShow=blogModel.ShowWriter,
				Description=blogModel.Description,
				State=blogModel.IsActive,
                AuthorId=blogModel.AuthorId,
				UserId= userId
			}
			);
            return Json(result);
        }
		[HttpGet]
		public async Task<IActionResult> Edit(string Id)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			ViewBag.AllAuthor = new SelectList(_blogFacad.GetAllAuthorService.Execute().Result.Data, "Id", "Name");
			ViewBag.AllBlogTag = new SelectList(_blogFacad.GetListBlogTagService.Execute().Result, "Id", "Name");
			ViewBag.AllCategoryBlog = new SelectList(_blogFacad.GetAllCategoryBlogService.Execute().Result.Data, "Id", "Name");
			var blog=await _blogFacad.GetEditBlogService.Execute(Id);
			return View(blog.Data);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(EditBlogDto editBlog)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var userId = ClaimUtility.GetUserId(User);
			if (userId == null)
			{
				return Json(new ResultDto()
				{
					IsSuccess = false,
					Message = MessageInUser.MessageUserNotLogin
				});
			}
			var result =await _blogFacad.EditBlogService.Execute(new EditBlogDto
			{ 
			Id = editBlog.Id,
			Title = editBlog.Title,
			AuthorId = editBlog.AuthorId,
			CategoryBlog=editBlog.CategoryBlog,
		    Content=editBlog.Content,
			Description = editBlog.Description,
			Image=editBlog.Image,
			IsActive=editBlog.IsActive,
			Keywords=editBlog.Keywords,
			MetaTag=editBlog.MetaTag,
			MinPic=editBlog.MinPic,
			ShowWriter=editBlog.ShowWriter,
			Slug=editBlog.Slug,
		    BlogTags = editBlog.BlogTags,
			UserId=userId
			});
			return Json(result);
		}
		[HttpPost]
		public async Task<IActionResult> Delete(string blogId)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var result =await _blogFacad.RemoveBlogService.Execute(blogId);
			return Json(result);
		}
	}
}
