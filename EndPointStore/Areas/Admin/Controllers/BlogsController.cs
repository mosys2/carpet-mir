using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Langueges.Queries;

namespace EndPointStore.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class BlogsController : Controller
	{
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        public BlogsController(IGetAllLanguegeService getAllLanguegeService)
        {
			_getAllLanguegeService = getAllLanguegeService;   
        }
        public async Task<IActionResult> Index()
		{

			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
            ViewBag.AllLanguege = new SelectList(await _getAllLanguegeService.Execute(), "Id", "Name");
            return View();
		}

    }
}
