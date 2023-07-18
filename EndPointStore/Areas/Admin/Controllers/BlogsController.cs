using EndPointStore.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Blogs.Commands.AddNewBlog;
using Store.Application.Services.Blogs.Commands.AddNewBlogTag;
using Store.Application.Services.Blogs.Queries.GetAllCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetBlogTag;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class BlogsController : Controller
	{
        private readonly IGetAllLanguegeService _getAllLanguegeService;
		private readonly IGetAllCategoryBlogService _getAllCategoryBlogService;
		private readonly IGetListBlogTagService _getListBlogTagService;
		private readonly IAddNewBlogTagService _addNewBlogTagService;
		private readonly IAddNewBlogService _addNewBlogService;
        public BlogsController(IGetAllLanguegeService getAllLanguegeService
	    ,IGetAllCategoryBlogService getAllCategoryBlogService,
			IGetListBlogTagService getListBlogTagService,
			IAddNewBlogTagService addNewBlogTagService,
            IAddNewBlogService addNewBlogService

            )
        {
			_getAllLanguegeService = getAllLanguegeService;   
			_getAllCategoryBlogService = getAllCategoryBlogService;
			_getListBlogTagService = getListBlogTagService;
			_getListBlogTagService= getListBlogTagService;
			_addNewBlogTagService = addNewBlogTagService;
			_addNewBlogService = addNewBlogService;
        }
        public async Task<IActionResult> Index()
		{

			return View();
		}
		[HttpPost]
        public async Task<IActionResult> CreateBlogTag(BlogTagDto blog)
        {
			var result=await _addNewBlogTagService.Execute(new BlogTagDto{
			LanguegeId = blog.LanguegeId,
			Name=blog.Name,
			});
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogTagList(string? Languege)
        {
			var result = await _getListBlogTagService.Execute(Languege);
            return Json(result);
        }
        [HttpGet]
		public async Task<IActionResult> Create(string? LanguegeId)
		{
			ViewBag.AllBlogTag= new SelectList( _getListBlogTagService.Execute(LanguegeId).Result.Data, "Id", "Name");
            ViewBag.AllCategoryBlog =new SelectList(_getAllCategoryBlogService.Execute(LanguegeId).Result.Data, "Id", "Name");
            ViewBag.AllLanguege = new SelectList(await _getAllLanguegeService.Execute(), "Id", "Name");
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
            //var userId = ClaimUtility.GetUserId(User);
            //if (userId == null)
            //{
            //    return Json(new ResultDto()
            //    {
            //        IsSuccess = false,
            //        Message = MessageInUser.MessageUserNotLogin
            //    });
            //}
            var result =await _addNewBlogService.Execute(new RequestBlogDto
			{
				Title=blogModel.Title,
				Image=blogModel.Image,
				LanguegeId=blogModel.LanguegeId,
				ShowAt=blogModel.ShowAt,
				BlogTags=blogModel.BlogTags,
				CategoryBlogId=blogModel.CategoryBlog,
                Key="slug",
				Content=blogModel.Content,
				Writer=blogModel.Writer,
				WriterShow=blogModel.ShowWriter,
				Caption=blogModel.Caption,
				State=blogModel.IsActive,
				UserId= "59fe1e9b-bee8-4d01-a8c4-10931d4bc4fc"
            }
			);
            return Json(result);
        }

    }
}
