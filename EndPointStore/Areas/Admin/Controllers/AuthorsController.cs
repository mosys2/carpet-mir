using EndPointStore.Areas.Admin.Models.ViewModelAuthor;
using EndPointStore.Areas.Admin.Models.ViewModelBrand;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Authors.Commands.RemoveAuthor;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AuthorsController : Controller
	{
        private readonly IGetAllLanguegeService _getAllLanguegeService;
		private readonly IAddNewAuthorService _addNewAuthorService;
		private readonly IRemoveAuthorService _removeAuthorService;
		private readonly IGetAllAuthorService _getAllAuthorService;
        public AuthorsController(IGetAllLanguegeService getAllLanguegeService
			,IGetAllAuthorService getAllAuthorService,
			IAddNewAuthorService addNewAuthorService,
			IRemoveAuthorService removeAuthorService)
        {
			_getAllLanguegeService = getAllLanguegeService;
			_addNewAuthorService = addNewAuthorService;
			_removeAuthorService = removeAuthorService;
			_getAllAuthorService = getAllAuthorService;

        }
		[HttpGet]
        public async Task<IActionResult> Index(string? lang)
		{
            var languages = await _getAllLanguegeService.Execute();
            if (!string.IsNullOrEmpty(lang))
            {
                lang = languages.Where(p => p.Name == lang).FirstOrDefault().Id;
            }
            var listAuthor = await _getAllAuthorService.Execute(lang);
            ViewBag.AllLanguege = new SelectList(languages, "Id", "Name");
            ViewModelAuthor viewModelAuthor = new ViewModelAuthor()
            {
                AddNewAuthor = new AddNewAuthorModel(),
                GetAllAuthors = listAuthor.Data,
                AllLangueges = languages,
            };
            return View(viewModelAuthor);
		}
        [HttpPost]
        public async Task<IActionResult> Create(AddNewAuthorModel authorModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addNewAuthorService.Excute(new AuthorDto {
                Id=authorModel.Id,
                IsActive=authorModel.IsActive,
                Name=authorModel.Name,
                LanguegeId=authorModel.LanguegeId,
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string authorId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _removeAuthorService.Execute(authorId);
            return Json(result);
        }
    }
}
