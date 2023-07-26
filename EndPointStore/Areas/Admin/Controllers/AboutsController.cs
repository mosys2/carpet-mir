using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Index()
        {
			
            var about =await _getAboutService.Execute();
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
