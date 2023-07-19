using EndPointStore.Areas.Admin.Models.ViewModelCategoryBlog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Blogs.Commands.AddNewCategoryBlog;
using Store.Application.Services.Blogs.Commands.RemoveCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Langueges.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryBlogsController : Controller
    {
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        private readonly IGetCategoryBlogService _getCategoryBlogService;
        private readonly IAddNewCategoryBlogService _addNewCategoryBlogService;
        private readonly IRemoveCategoryBlogService _removeCategoryBlogService;
        public CategoryBlogsController(IGetAllLanguegeService getAllLanguegeService
            ,IGetCategoryBlogService categoryBlogService,
            IAddNewCategoryBlogService addNewCategoryBlogService,
            IRemoveCategoryBlogService removeCategoryBlogService
            )
        {
            _getAllLanguegeService = getAllLanguegeService;
            _getCategoryBlogService = categoryBlogService;
            _addNewCategoryBlogService = addNewCategoryBlogService;
            _removeCategoryBlogService = removeCategoryBlogService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? LanguegeId)
        {
            ViewBag.AllLanguege = new SelectList(await _getAllLanguegeService.Execute(), "Id", "Name");
            var listCategoryBlog=_getCategoryBlogService.Execute(LanguegeId).Result.Data;
            ViewModelCategoryBlog viewModelCategoryBlog = new ViewModelCategoryBlog()
            {
                GetCategoryBlogs = listCategoryBlog,
                RequestCategoryBlog=new RequestCategoryBlogDto()
            };
            return View(viewModelCategoryBlog);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequestCategoryBlogDto requestCategory)
        {
            var result =await _addNewCategoryBlogService.Execute(new RequestCategoryBlogDto
            {
                Id = requestCategory.Id,
                Description = requestCategory.Description,
                IsActive = requestCategory.IsActive,
                LanguegeId = requestCategory.LanguegeId,
                Name = requestCategory.Name,
                Slug = requestCategory.Slug,
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string categoryBlogId)
        {
            var result = await _removeCategoryBlogService.Execute(categoryBlogId);
            return Json(result);
        }
    }
}
