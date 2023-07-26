using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Command.Site.LogOutUser;
using Store.Application.Services.Users.Command.Site.SignInUser;
using Store.Application.Services.Users.Command.Site.SignUpUser;

namespace EndPointStore.Areas.Admin.Controllers
{
   
    public class AuthenticationController : Controller
    {
        private readonly ISignUpUserService _signUpUserService;
        private readonly ISignInUserService _signInUserService;
        private readonly IlogOutUser _ilogOutUser;
        //private readonly SignInManager<Login> _signInManager;
        public AuthenticationController(ISignUpUserService signUpUserService, ISignInUserService signInUserService, IlogOutUser ilogOutUser)
        {
            _signUpUserService = signUpUserService;
            _signInUserService = signInUserService;
            _ilogOutUser = ilogOutUser;
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl = "/")
        {
            return View(new RequestSignInUserDto
            {
                Url = ReturnUrl,
            });
        }
    }
}
