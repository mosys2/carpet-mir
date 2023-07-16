using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.HomePages.Commands.RemoveSlider;
using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IAddNewSliderService _addsliderService;
        private readonly IGetSliderService _getsliderService;
        private readonly IRemoveSliderService _removesliderService;
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        public SlidersController(IAddNewSliderService addNewSliderService,
            IGetSliderService getSliderService,
            IRemoveSliderService removeSliderService,
            IGetAllLanguegeService getAllLanguegeService
            )
        {
            _addsliderService = addNewSliderService;
            _getsliderService = getSliderService;
            _removesliderService = removeSliderService;
            _getAllLanguegeService= getAllLanguegeService;
        }
        public async Task<IActionResult> Index()
        {
           var sliderList=await _getsliderService.Execute();
            ViewBag.AllLanguege =new SelectList(await _getAllLanguegeService.Execute(),"Id","Name");
            return View(sliderList);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequstSliderDto slider)
        {
            if (string.IsNullOrEmpty(slider.UrlImage))
            {
                return Json(new ResultDto()
                {
                    IsSuccess = false,
                    Message = "آدرس تصویر را وارد کنید!"
                });
            }
            var addSlider = await _addsliderService.Execute(new RequstSliderDto{
            Id= slider.Id,
            Description = slider.Description,
            Link=slider.Link,
            Title=slider.Title,
            IsActive=slider.IsActive,
            UrlImage=slider.UrlImage,
            LanguegeId=slider.LanguegeId,
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
