using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Abouts.Commands;
using Store.Application.Services.Abouts.Queries;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutsController : Controller
    {
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        private readonly IGetAboutService _getAboutService;
        private readonly IEditAboutService _editAboutService;
        public AboutsController(IGetAllLanguegeService getAllLanguegeService
            ,IEditAboutService editAboutService
            ,IGetAboutService getAboutService)
        {
			
			_getAllLanguegeService = getAllLanguegeService;
            _getAboutService = getAboutService;
            _editAboutService = editAboutService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? lang)
        {
			var languages = await _getAllLanguegeService.Execute();
			if (!string.IsNullOrEmpty(lang))
			{
				lang =languages.Where(p => p.Name == lang).FirstOrDefault().Id;
			}
            ViewBag.AllLanguages = new SelectList(languages, "Id", "Name");
            var about =await _getAboutService.Execute(lang);
            return View(about);
        }
		[HttpPost]
		public async Task<IActionResult> Edit(EditAboutDto editAbout)
		{
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var result =await _editAboutService.Execute(editAbout);
			return Json(result);
		}
	}
}
