using EndPointStore.Areas.Admin.Models.ViewModelMaterial;
using EndPointStore.Areas.Admin.Models.ViewModelSize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Materials.Commands.AddNewMaterial;
using Store.Application.Services.Materials.Commands.RemoveMaterial;
using Store.Application.Services.Materials.Queries.GetAllMaterial;
using Store.Application.Services.Sizes.Commands.AddNewSize;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MaterialsController : Controller
    {
        private readonly IAddNewMaterialService _addMaterialService;
        private readonly IGetAllMaterialService _getAllMaterialService;
        private readonly IRemoveMaterialService _removeMaterialService;
        public MaterialsController(IAddNewMaterialService addNewMaterialService,
            IGetAllMaterialService getAllMaterialService,IRemoveMaterialService removeMaterialService
            )
        {
            _addMaterialService = addNewMaterialService;
            _getAllMaterialService = getAllMaterialService;
            _removeMaterialService = removeMaterialService;
        }
        public async Task<IActionResult> Index()
        {
            var listMaterial = await _getAllMaterialService.Execute();
            ViewModelMaterial viewModelMaterial = new ViewModelMaterial()
            {
                AddNewMaterialModel = new AddNewMaterialModel(),
                GetAllMaterials = listMaterial.Data,
            };
            return View(viewModelMaterial);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewMaterialModel materialModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addMaterialService.Execute(new AddNewMaterial
            {
                Id = materialModel.Id,
                Name = materialModel.Name,
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string materialId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _removeMaterialService.Execute(materialId);
            return Json(result);
        }
    }
}
