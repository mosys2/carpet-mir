using Microsoft.AspNetCore.Mvc;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Account : Controller
    {
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
