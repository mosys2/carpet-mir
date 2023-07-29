using Microsoft.AspNetCore.Mvc;

namespace EndPointStore.Controllers
{
    public class BlogsController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
