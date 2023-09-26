using EndPointStore.Areas.Admin.Models.ViewModelRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Roles.Commands.AddNewRole;
using Store.Application.Services.Roles.Commands.RemoveRole;
using Store.Application.Services.Roles.Queries.GetAllRole;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IAddNewRoleService _addNewRoleService;
        private readonly IGetAllRoleService _getAllRoleService;
        private readonly IRemoveRoleService _removeRoleService;
        public RolesController(IAddNewRoleService addNewRoleService,
            IGetAllRoleService getAllRoleService,
            IRemoveRoleService removeRoleService)
        {
            _addNewRoleService = addNewRoleService;
            _getAllRoleService = getAllRoleService;
            _removeRoleService = removeRoleService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _getAllRoleService.Execute();
            ViewModelRole viewModelRole = new ViewModelRole()
            {
                AddNewRole=new AddNewRoleModel(),
                GetAllRoles=roles
            };
            return View(viewModelRole);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewRoleModel addNewRole)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addNewRoleService.Excute(new RoleDto
            {
                Id = addNewRole.Id,
                Name = addNewRole.Name,
                PersianTitle = addNewRole.PersianTitle,
                Description = addNewRole.Description,
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string roleId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _removeRoleService.Execute(roleId);
            return Json(result);
        }
    }
}
