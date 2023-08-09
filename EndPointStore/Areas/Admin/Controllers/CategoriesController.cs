using EndPointStore.Areas.Admin.Models.ViewModelCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Interfaces.FacadPattern;
using Store.Application.Services.Colors.Queries.GetAllColor;
using Store.Application.Services.Materials.Queries.GetAllMaterial;
using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using Store.Application.Services.ProductsSite.Queries.GetParentCategory;
using Store.Application.Services.Shapes.Queries.GetAllShape;
using Store.Application.Services.Sizes.Queries.GetAllSize;
using Store.Application.Services.Users.Command.DeleteUser;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IGetAllSizeService _getAllSizeService;
        private readonly IGetAllColorService _getAllColorService;
        private readonly IGetAllMaterialService _getAllMaterialService;
        private readonly IGetAllShapeService _getAllShapeService;
        public CategoriesController(IProductFacad productFacad
            , IGetAllSizeService getAllSizeService
            , IGetAllColorService getAllColorService
            , IGetAllMaterialService getAllMaterialService
            , IGetAllShapeService getAllShapeService
            )
        {
            _productFacad =productFacad;
            _getAllColorService = getAllColorService;
            _getAllMaterialService = getAllMaterialService;
            _getAllShapeService = getAllShapeService;
            _getAllSizeService = getAllSizeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listView =await _productFacad.GetParentCategory.Execute();
            List<ParentCategoryDto> list = new List<ParentCategoryDto>();
            list.Add(new ParentCategoryDto()
            {
                Id = null,
                ParentId = null,
                Name = "هیچکدام",
            }
          );
            list.AddRange(listView);
            ViewModelCategories viewModelCategories = new ViewModelCategories()
            {
                AddCategoryView=new AddCategoryViewDto(),
                ParentCategory= listView,
            };
          
            ViewBag.Category = new SelectList(list, "Id", "Name");
            return View(viewModelCategories);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryViewDto addCategory)
        {
            var result = await _productFacad.AddCategoryService.Execute(
                new RequestCatgoryDto
                {
                   
                    OrginalName = addCategory.Name,
                    ParentId = addCategory.ParentId,
                    Name = addCategory.Name,
                    CssClass = addCategory.CssClass,
                    Icon = addCategory.Icon,
                    Description = addCategory.Description,
                    IsActive = addCategory.IsActive,
                    Slug = addCategory.Slug,
                    Sort = addCategory.Sort,
                    Id= addCategory.Id,
                }
                );
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string categoryId)
        {
            return Json(await _productFacad.GetDeleteCategory.Execute(categoryId));
        }
        [HttpGet]
        public async Task<IActionResult> ShowFeature(string Id)
        {
            var sizes = await _getAllSizeService.Execute();
            var colors = await _getAllColorService.Execute();
            var materials = await _getAllMaterialService.Execute();
            var shapes = await _getAllShapeService.Execute();
            ViewBag.Id= Id;
            ViewBag.Sizes = new SelectList(sizes.Data,"Id", "Meterage");
            ViewBag.Colors = new SelectList(colors.Data, "Id", "Name");
            ViewBag.Materials = new SelectList(materials.Data, "Id", "Name");
            ViewBag.Shapes = new SelectList(shapes.Data, "Id", "Name");
            return View();
        }
    }
}

