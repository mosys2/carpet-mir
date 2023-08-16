﻿using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Command.Site.LogOutUser;
using Store.Application.Services.Users.Command.Site.SignInUser;
using Store.Application.Services.Users.Command.Site.SignUpUser;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ISignUpUserService _signUpUserService;
        private readonly ISignInUserService _signInUserService;
        private readonly IlogOutUser _ilogOutUser;
        //private readonly SignInManager<Login> _signInManager;
        public AccountController(ISignUpUserService signUpUserService, ISignInUserService signInUserService, IlogOutUser ilogOutUser)
        {
            _signUpUserService = signUpUserService;
            _signInUserService = signInUserService;
            _ilogOutUser = ilogOutUser;
        }
		
		[HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl = "/Admin/Home")
        {
            return View(new RequestSignInUserDto
            {
                Url = ReturnUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(RequestSignInUserDto signInUser)
        {
            if (string.IsNullOrEmpty(signInUser.Url))
            {
                signInUser.Url="/Admin/Home";
            }
            var result = await _signInUserService.Execute(
               new RequestSignInUserDto()
               {
                   Password = signInUser.Password
                   ,
                   UserName = signInUser.UserName,
                   Url = signInUser.Url
               });
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> Forget(RequestForgetDto requestForget)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto { IsSuccess=false, Message=MessageInUser.InvalidForm });
            }
            return Json("");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _ilogOutUser.Execute();
            return Json(new ResultDto { IsSuccess=true });
        }
      
    }
}
