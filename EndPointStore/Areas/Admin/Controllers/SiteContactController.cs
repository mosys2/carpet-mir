using EndPointStore.Areas.Admin.Models.ViewModelSiteContact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.HomePages.Commands.AddNewSlider;
using Store.Application.Services.SiteContacts.Commands.AddNewSiteContact;
using Store.Application.Services.SiteContacts.Commands.RemoveSiteContact;
using Store.Application.Services.SiteContacts.Queries.GetAllSiteContact;
using Store.Application.Services.SiteContacts.Queries.GetContactType;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SiteContactController : Controller
    {
        private readonly IGetContactTypeService _getContactTypeService;
        private readonly IAddNewSiteContactService _addNewSiteContactService;
        private readonly IGetAllSiteContactService _getAllSiteContactService;
        private readonly IRemoveSiteContactService _removeSiteContactService;
        public SiteContactController(IGetContactTypeService getContactTypeService
            , IAddNewSiteContactService addNewSiteContactService
            , IGetAllSiteContactService getAllSiteContactService
            ,IRemoveSiteContactService removeSiteContactService
            )
        {
            _getContactTypeService = getContactTypeService;
            _addNewSiteContactService=addNewSiteContactService;
            _getAllSiteContactService = getAllSiteContactService;
            _removeSiteContactService= removeSiteContactService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listSiteContact = await _getAllSiteContactService.Execute();
            ViewModelSiteContact viewModelSiteContact = new ViewModelSiteContact()
            {
                AddNewSiteContact=new AddNewSiteContactModel(),
                GetAllSiteContacts=listSiteContact
            };
            var ItemContactType =await _getContactTypeService.Execute();
            ViewBag.ContactType = new SelectList(ItemContactType, "Id", "Name");
            return View(viewModelSiteContact);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewSiteContactModel  contactModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var addSiteContact = await _addNewSiteContactService.Execute(new AddNewSiteContactDto{
            Id=contactModel.Id,
            ContactType=contactModel.ContactType,
            CssClass=contactModel.CssClass,
            IsActive = contactModel.IsActive,
            Title = contactModel.Title,
            Value = contactModel.Value
            });
            return Json(addSiteContact);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string idSiteContact)
        {
            var SiteContact = await _removeSiteContactService.Execute(idSiteContact);
            return Json(SiteContact);
        }
    }
}
