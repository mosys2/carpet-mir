using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging;
using Store.Application.Services.Groups.Queries.GetItemGroup;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Pages.Commands.AddNewPageCreator;
using Store.Application.Services.Pages.Commands.EditPageCreator;
using Store.Application.Services.Pages.Commands.RemovePageCreator;
using Store.Application.Services.Pages.Queries.GetAllPageCreator;
using Store.Application.Services.Pages.Queries.GetEditPageCreator;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PagesController : Controller
    {
        private readonly IGetPageCreatorService _getPageCreatorService;
        private readonly IAddNewPageCreatorService _addNewPageCreatorService;
        private readonly IEditPageCreatorService _editPageCreatorService;
        private readonly IRemovePageCreatorService _removePageCreatorService;
        private readonly IGetEditPageCreatorService _getEditPageCreatorService;
        private readonly IGetSettingServices _getSettingServices;
        private readonly IGetItemGroupService _getItemGroupService;
        public PagesController(IGetPageCreatorService getPageCreatorService
			, IAddNewPageCreatorService addNewPageCreatorService
            ,IEditPageCreatorService editPageCreatorService
            , IGetEditPageCreatorService getEditPageCreatorService
            ,IRemovePageCreatorService removePageCreatorService
            , IGetSettingServices settingServices
            , IGetItemGroupService getItemGroupService
            )
        {
            _getPageCreatorService = getPageCreatorService;
            _addNewPageCreatorService = addNewPageCreatorService;
            _editPageCreatorService = editPageCreatorService;
            _removePageCreatorService = removePageCreatorService;
            _getEditPageCreatorService= getEditPageCreatorService;
            _getSettingServices = settingServices;
            _getItemGroupService = getItemGroupService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? searchkey, int Page = 1)
        {
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var result =await _getPageCreatorService.Execute(new RequestGetPageCreatorDto{
                Page = Page,
                SearchKey = searchkey,
                PageSize = pagesize,
                Category = null,
                Tag = null
            });
            return View(result);
        }
		public async Task<IActionResult> Create()
		{
            var listGroupItem = _getItemGroupService.Execute();
            List<GetItemGroupDto> getItemGroups = new List<GetItemGroupDto>();
            getItemGroups.Add(new GetItemGroupDto
            {
                Id=null,
                Name="بدون انتخاب"
            });
            getItemGroups.AddRange(listGroupItem.Result.Data);
            
            ViewBag.GroupItem = new SelectList(getItemGroups, "Id", "Name");
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
            var listGroupItem = _getItemGroupService.Execute();
            List<GetItemGroupDto> getItemGroups = new List<GetItemGroupDto>();
            getItemGroups.Add(new GetItemGroupDto
            {
                Id = null,
                Name = "بدون انتخاب"
            });
            getItemGroups.AddRange(listGroupItem.Result.Data);
            ViewBag.GroupItem = new SelectList(getItemGroups, "Id", "Name");
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
