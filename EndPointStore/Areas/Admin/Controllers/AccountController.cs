using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Store.Application.Services.Users.Command.ForgotPasswordByEmail;
using Store.Application.Services.Users.Command.Site.LogOutUser;
using Store.Application.Services.Users.Command.Site.SignInUser;
using Store.Application.Services.Users.Command.Site.SignUpUser;
using Store.Common.Constant;
using Store.Common.Dto;
using System.Net;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly ISignUpUserService _signUpUserService;
        private readonly ISignInUserService _signInUserService;
        private readonly IlogOutUser _ilogOutUser;
        private readonly IForgotPasswordByEmailService _forgotPassword;
        //private readonly SignInManager<Login> _signInManager;
        public AccountController(ISignUpUserService signUpUserService,
            ISignInUserService signInUserService,
            IlogOutUser ilogOutUser,
            IForgotPasswordByEmailService forgotPassword)
        {
            _signUpUserService = signUpUserService;
            _signInUserService = signInUserService;
            _ilogOutUser = ilogOutUser;
            _forgotPassword = forgotPassword;
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
                return Json(new ResultDto { IsSuccess=false, Message=MessageInUser.InvalidFormValue });
            }
           var result=await _forgotPassword.CheckEmail(new ForgotPasswordConfirmationDto { Email=requestForget.Email });
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string UserId,string Token)
        {
            return View(new ResetPasswordDto
            {
                Token=Token,
                UserId=UserId
            });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPassword)
        {
            if(!ModelState.IsValid)
            {
                return Json(new ResultDto { IsSuccess=false, Message=MessageInUser.InvalidFormValue });
            }
            var result=await _forgotPassword.ResetPassword(resetPassword);
            return Json(result);
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
