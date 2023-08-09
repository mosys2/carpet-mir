using EndPointStore.Areas.Admin.Models.ViewModelColor;
using EndPointStore.Areas.Admin.Models.ViewModelSize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Colors.Commands.AddNewColor;
using Store.Application.Services.Sizes.Commands.AddNewSize;
using Store.Application.Services.Sizes.Commands.RemoveSize;
using Store.Application.Services.Sizes.Queries.GetAllSize;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SizesController : Controller
    {
        private readonly IAddNewSizeService _addNewSizeService;
        private readonly IRemoveSizeService _removeSizeService;
        private readonly IGetAllSizeService _getAllSizeService;
        public SizesController(IAddNewSizeService addNewSizeService
            , IGetAllSizeService getAllSizeService
            ,IRemoveSizeService removeSizeService)
        {
            _addNewSizeService = addNewSizeService;
            _removeSizeService = removeSizeService;
            _getAllSizeService = getAllSizeService;
        }
        public async Task<IActionResult> Index()
        {
            var listSizes = await _getAllSizeService.Execute();
            ViewModelSize viewModelSizes = new ViewModelSize()
            {
                AddNewSizeModel = new AddNewSizeModel(),
                GetAllSizes = listSizes.Data,
            };
            return View(viewModelSizes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewSizeModel sizeModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addNewSizeService.Execute(new AddNewSize
            {
                Id = sizeModel.Id,
                Width = sizeModel.Width,
                Lenght = sizeModel.Lenght
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string sizeId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _removeSizeService.Execute(sizeId);
            return Json(result);
        }
    }
}
