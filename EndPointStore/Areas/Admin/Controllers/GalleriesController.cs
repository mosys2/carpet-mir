using EndPointStore.Areas.Admin.Models.ViewModelAuthor;
using EndPointStore.Areas.Admin.Models.ViewModelGallery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Galleries.Commands.AddNewGallery;
using Store.Application.Services.Galleries.Commands.RemoveGallery;
using Store.Application.Services.Galleries.Queries.GetListGallery;
using Store.Application.Services.Galleries.Queries.GetParentAndSubGallery;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GalleriesController : Controller
    {
        private readonly IAddNewGalleryService _addGalleryService;
        private readonly IRemoveGalleryService _removeGalleryService;
        private readonly IGetParentAndSubGalleryService _parentAndSubGalleryService;
        private readonly IGetListGalleryService _getListGalleryService;
        public GalleriesController(
            IAddNewGalleryService addNewGalleryService,
            IRemoveGalleryService removeGalleryService,
            IGetParentAndSubGalleryService getParentAndSubGalleryService,
            IGetListGalleryService getListGalleryService
            )
        {
            _addGalleryService = addNewGalleryService;
            _removeGalleryService = removeGalleryService;
            _getListGalleryService = getListGalleryService;
            _parentAndSubGalleryService = getParentAndSubGalleryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listGallerySubParent = await _parentAndSubGalleryService.Execute();
            List<ParentAndSubGalleryDto> listGallery = new List<ParentAndSubGalleryDto>();
            listGallery.Add(new ParentAndSubGalleryDto()
            {
                Id = null,
                ParentId = null,
                Name = "هیچکدام",
            }
          );
            listGallery.AddRange(listGallerySubParent);
            ViewModelGallery viewModelGallery = new ViewModelGallery()
            {
                AddNewGallery = new AddNewGallery(),
                Galleries = listGallerySubParent,
            };
            ViewBag.Gallery = new SelectList(listGallery, "Id", "Name");
            return View(viewModelGallery);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewGallery addNewGallery)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addGalleryService.Execute(new RequestGalleryDto
            {
                Id = addNewGallery.Id,
                IsActive = addNewGallery.IsActive,
                Name = addNewGallery.Name,
                Description = addNewGallery.Description,
                ParentId=addNewGallery.ParentId
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string galleryId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _removeGalleryService.Execute(galleryId);
            return Json(result);
        }
    }
}
