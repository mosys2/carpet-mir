using Store.Application.Services.Users.Command.Site.SignInUser;

namespace EndPointStore.Areas.Admin.Models.ViewModelLogin
{
    public class LoginViewModel
    {
        public RequestSignInUserDto requestSignInUser { get; set; }
        public RequestForgetDto requestForget { get; set; }

    }
}
