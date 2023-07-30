using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Command.Site.LogOutUser;
using Store.Application.Services.Users.Command.Site.SignInUser;
using Store.Application.Services.Users.Command.Site.SignUpUser;
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
        public async Task<IActionResult> Login(string ReturnUrl = "/")
        {
            return View(new RequestSignInUserDto
            {
                Url = ReturnUrl,
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(RequestSignInUserDto signInUser)
        {
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
        public async Task<IActionResult> AccessDenied()
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
