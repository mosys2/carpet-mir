using EndPointStore.Areas.Admin.Models.ViewModelSlider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.HomePages.Commands.RemoveSlider;
using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IAddNewSliderService _addsliderService;
        private readonly IGetSliderService _getsliderService;
        private readonly IRemoveSliderService _removesliderService;
        public SlidersController(IAddNewSliderService addNewSliderService,
            IGetSliderService getSliderService,
            IRemoveSliderService removeSliderService
            )
        {
            _addsliderService = addNewSliderService;
            _getsliderService = getSliderService;
            _removesliderService = removeSliderService;
        }
        public async Task<IActionResult> Index(string lang)
        {
            var sliderList=await _getsliderService.Execute();
            ViewModelSlider viewModelSlider = new ViewModelSlider()
            {
                ListSliders=sliderList,
            };
            return View(viewModelSlider);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequstSliderDto slider)
        {
            if(!ModelState.IsValid)
            {
                return Json(new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var addSlider = await _addsliderService.Execute(new RequstSliderDto{
            Id= slider.Id,
            Description = slider.Description,
            Link=slider.Link,
            Title=slider.Title,
            IsActive=slider.IsActive,
            UrlImage=slider.UrlImage,
            });
            return Json(addSlider);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string idSlider)
        {
            var sliderDelete = await _removesliderService.Execute(idSlider);
            return Json(sliderDelete);
        }
    }
}
