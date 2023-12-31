﻿using EndPointStore.Areas.Admin.Models.ViewModelProfile;
using EndPointStore.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Commands.CheckEmail;
using Store.Application.Services.Commands.CheckUser;
using Store.Application.Services.Profile.Commands.ChangePassword;
using Store.Application.Services.Profile.Commands.ProfileUpdate;
using Store.Application.Services.Profile.Queries;
using Store.Application.Services.SettingsSite.Queries;
using Store.Application.Services.Users.Command.DeleteUser;
using Store.Application.Services.Users.Command.EditUser;
using Store.Application.Services.Users.Command.RegisterUser;
using Store.Application.Services.Users.Command.RegisterUser.CreateDto;
using Store.Application.Services.Users.Queries.Edit;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Users;
using System.ComponentModel;
using System.Reflection;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class UsersController : Controller
    {

        private readonly IGetUsersServices _usersServices;
        private readonly IGetRolesService _rolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveService _removeService;
        private readonly IGetEditUserService _geteditUserService;
        private readonly IEditUserService _editUserService;
        private readonly ICheckEmailService _checkEmailService;
        private readonly IDatabaseContext _databaseContext;
        private readonly IGetSettingServices _getSettingServices;
        private readonly IGetProfileUserService _getProfileUserService;
        private readonly IProfileUpdateService _profileUpdateService;
        private readonly IChangePasswordService _changePasswordService;
        public UsersController(IGetUsersServices getUsersServices,
            IGetRolesService rolesService
            , IRegisterUserService registerUserService
            , IRemoveService removeService
            , IGetEditUserService geteditUserService
            , IEditUserService editUserService
            , ICheckEmailService checkEmailService
            , IDatabaseContext databaseContext
            , IGetSettingServices getSettingServices
            , IGetProfileUserService getProfileUserService
            ,IProfileUpdateService profileUpdateService
            ,IChangePasswordService changePasswordService
            )
        {
            _rolesService = rolesService;
            _usersServices = getUsersServices;
            _registerUserService = registerUserService;
            _removeService = removeService;
            _geteditUserService = geteditUserService;
            _editUserService = editUserService;
            _checkEmailService = checkEmailService;
            _databaseContext = databaseContext;
            _getSettingServices = getSettingServices;
            _getProfileUserService = getProfileUserService;
            _profileUpdateService = profileUpdateService;
            _changePasswordService = changePasswordService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index(string? searchkey, int Page = 1)
        {
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var ResultUsers = await _usersServices.Execute(

                new RequestGetUsersDto
                {

                    Page = Page,
                    SearchKey = searchkey,
                    PageSize= pagesize,
                    Category=null,
                    Tag=null
                }
                );
            return View(ResultUsers);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_rolesService.Execute().Data, "Name", "PersianTitle");
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateDto request)
        {
            if (ModelState.IsValid)
            {
                var result = await _registerUserService.Execute(new RequestRegisterUserDto
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Password = request.Password,
                    RePassword = request.RePassword,
                    IsActive = request.IsActive,
                    Gender = request.Gender,
                    Mobile = request.Mobile,
                    Email = request.Email,
                    Address = request.Address,
                    Phone = request.Phone,
                    Roles = request.Roles,
                }
               );
                return Json(result);
            }
            return Json(new ResultDto
            {
                IsSuccess = false,
                Message = "ثبت ناموفق"
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string UserId)
        {
            return Json(await _removeService.Execute(UserId));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			ViewBag.Roles = new SelectList(_rolesService.Execute().Data, "Name", "PersianTitle");
            var result = await _geteditUserService.Execute(Id);
            return View(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserDto request)
        {
			if (!ModelState.IsValid)
			{
				return Json(new ResultDto
				{
					IsSuccess = false,
					Message = MessageInUser.IsValidForm
				});
			}
			var result = await _editUserService.Execute(new EditUserDto
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Gender = request.Gender,
                IsActive = request.IsActive,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                Mobile = request.Mobile,
                IdesInRole = request.IdesInRole
            }
           );
            return Json(result);
        }
        [Authorize(Roles = "Admin,Operator")]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
             var userId = ClaimUtility.GetUserId(User);
            if(string.IsNullOrEmpty(userId))
            {
                RedirectToAction("Index", "Home");
            }
            var result = await _getProfileUserService.Execute(userId);
            ViewModelProfile viewModelProfile=new ViewModelProfile()
            {
                GetProfileUserDto=result,
                ChangePassModel=new ChangePassModel()
            };
            return View(viewModelProfile);
        }
        [Authorize(Roles = "Admin,Operator")]
        [HttpPost]
        public async Task<IActionResult> ProfileUpdate(UpdateProfileDto updateProfile)
        {
            var userId = ClaimUtility.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message=MessageInUser.MessageNotfindUser
                });
            }
            var result = await _getProfileUserService.Execute(userId);
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            return Json(await _profileUpdateService.Execute(new UpdateProfileDto
            {
                Id=userId,
                Address = updateProfile.Address,
                Image = updateProfile.Image,
                Password = updateProfile.Password,
                PhoneNumber = updateProfile.PhoneNumber
            }));
        }
        [Authorize(Roles = "Admin,Operator")]
        [HttpPost]
        public async Task<IActionResult> PasswordUpdate(ChangePassModel changePass)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            return Json(await _changePasswordService.Execute(new ChangePassDto
            {
                Email=changePass.Email,
                NewPassword=changePass.NewPassword,
                OldPassword=changePass.OldPassword,
            }));
        }
    }
}
