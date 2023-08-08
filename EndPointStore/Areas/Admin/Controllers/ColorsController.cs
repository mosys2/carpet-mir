using EndPointStore.Areas.Admin.Models.ViewModelAuthor;
using EndPointStore.Areas.Admin.Models.ViewModelColor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Colors.Commands.AddNewColor;
using Store.Application.Services.Colors.Commands.RemoveColor;
using Store.Application.Services.Colors.Queries.GetAllColor;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ColorsController : Controller
    {
        private readonly IAddNewColorService _addNewColor;
        private readonly IGetAllColorService _allColorService;
        private readonly IRemoveColorService _removeColorService;
        public ColorsController(IAddNewColorService addNewColorService
            , IGetAllColorService getAllColorService
            , IRemoveColorService removeColorService
            )
        {
            _addNewColor = addNewColorService;
            _allColorService = getAllColorService;
            _removeColorService = removeColorService;
        }
        public async Task<IActionResult> Index()
        {
            var listColors = await _allColorService.Execute();
            ViewModelColor viewModelColor = new ViewModelColor()
            {
                AddNewColorModel = new AddNewColorModel(),
                GetAllColors = listColors.Data,
            };
            return View(viewModelColor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewColorModel colorModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addNewColor.Execute(new AddNewColor
            {
                Id= colorModel.Id,
                Name= colorModel.Name,
                Value=colorModel.Value
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string colorId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _removeColorService.Execute(colorId);
            return Json(result);
        }
    }
}
