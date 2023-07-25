using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Pages.Commands.AddNewPageCreator;
using Store.Application.Services.Pages.Commands.EditPageCreator;
using Store.Application.Services.Pages.Commands.RemovePageCreator;
using Store.Application.Services.Pages.Queries.GetAllPageCreator;
using Store.Application.Services.Pages.Queries.GetEditPageCreator;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly IGetPageCreatorService _getPageCreatorService;
        private readonly IAddNewPageCreatorService _addNewPageCreatorService;
        private readonly IEditPageCreatorService _editPageCreatorService;
        private readonly IRemovePageCreatorService _removePageCreatorService;
        private readonly IGetEditPageCreatorService _getEditPageCreatorService;
		public PagesController(IGetPageCreatorService getPageCreatorService
			, IAddNewPageCreatorService addNewPageCreatorService
            ,IEditPageCreatorService editPageCreatorService
            , IGetEditPageCreatorService getEditPageCreatorService
            ,IRemovePageCreatorService removePageCreatorService
            )
        {
            _getPageCreatorService = getPageCreatorService;
            _addNewPageCreatorService = addNewPageCreatorService;
            _editPageCreatorService = editPageCreatorService;
            _removePageCreatorService = removePageCreatorService;
            _getEditPageCreatorService= getEditPageCreatorService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(RequestGetPageCreatorDto requestGetPage)
        {
			var result =await _getPageCreatorService.Execute(requestGetPage);
            return View(result);
        }
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> Create(PageCreatorDto pageCreator)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addNewPageCreatorService.Execute(pageCreator);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var result =await _getEditPageCreatorService.Execute(Id);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditPageCreatorDto pageCreatorDto)
        {
            var result =await _editPageCreatorService.Execute(pageCreatorDto);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string pageId)
        {

            var result = await _removePageCreatorService.Execute(pageId);
            return Json(result);
        }
    }
}
