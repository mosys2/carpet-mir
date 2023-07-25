using EndPointStore.Areas.Admin.Models.ViewModelCategoryBlog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Blogs.Commands.AddNewCategoryBlog;
using Store.Application.Services.Blogs.Commands.RemoveCategoryBlog;
using Store.Application.Services.Blogs.Queries.GetCategoryBlog;
using Store.Application.Services.Langueges.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryBlogsController : Controller
    {
        private readonly IBlogFacad _blogFacad;
        public CategoryBlogsController(IBlogFacad blogFacad)
        {
            _blogFacad = blogFacad;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listCategoryBlog= _blogFacad.GetCategoryBlogService.Execute().Result.Data;
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
            var result =await _blogFacad.AddNewCategoryBlogService.Execute(new RequestCategoryBlogDto
            {
                Id = requestCategory.Id,
                Description = requestCategory.Description,
                IsActive = requestCategory.IsActive,
                Name = requestCategory.Name,
                Slug = requestCategory.Slug,
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string categoryBlogId)
        {
            var result = await _blogFacad.RemoveCategoryBlogService.Execute(categoryBlogId);
            return Json(result);
        }
    }
}
