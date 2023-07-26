using EndPointStore.Areas.Admin.Models.ViewModelAuthor;
using EndPointStore.Areas.Admin.Models.ViewModelBrand;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class AuthorsController : Controller
	{
		private readonly IAddNewAuthorService _addNewAuthorService;
		private readonly IRemoveAuthorService _removeAuthorService;
		private readonly IGetAllAuthorService _getAllAuthorService;
        public AuthorsController(
			IGetAllAuthorService getAllAuthorService,
			IAddNewAuthorService addNewAuthorService,
			IRemoveAuthorService removeAuthorService)
        {
			_addNewAuthorService = addNewAuthorService;
			_removeAuthorService = removeAuthorService;
			_getAllAuthorService = getAllAuthorService;

        }
		[HttpGet]
        public async Task<IActionResult> Index()
		{
           
            var listAuthor = await _getAllAuthorService.Execute();
            ViewModelAuthor viewModelAuthor = new ViewModelAuthor()
            {
                AddNewAuthor = new AddNewAuthorModel(),
                GetAllAuthors = listAuthor.Data,
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
