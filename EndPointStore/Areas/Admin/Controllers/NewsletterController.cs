using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Newsletters.Commands.RemoveNewsletter;
using Store.Application.Services.Newsletters.Queries.GetAllNewsletter;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NewsletterController : Controller
    {
        private readonly IGetAllNewsLetterService _getAllNewsLetter;
        private readonly IGetSettingServices _getSettingServices;
        private readonly IRemoveNewsletterService _removeNewsletter;

        public NewsletterController(IGetAllNewsLetterService getAllNewsLetter,
            IGetSettingServices getSettingServices,
            IRemoveNewsletterService removeNewsletter)
        {
            _getAllNewsLetter = getAllNewsLetter;
            _getSettingServices = getSettingServices;
            _removeNewsletter = removeNewsletter;
        }
        public async Task<IActionResult> Index(string searchkey, int page = 1)
        {
            var pagesize = _getSettingServices.Execute().Result.Data.ShowPerPage;
            var result =await _getAllNewsLetter.Execute(page,pagesize,searchkey);
            return View(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string newsletterId)
        {
            var result=await _removeNewsletter.Execute(newsletterId);
            return Json(result);
        }
    }
   
}
