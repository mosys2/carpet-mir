using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Langueges.Queries;
using System.Xml.Linq;

namespace EndPointStore.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "LanguageSelect")]
    public class LanguageSelect: ViewComponent
    {
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        public LanguageSelect(IGetAllLanguegeService getAllLanguegeService)
        {
            _getAllLanguegeService=getAllLanguegeService;
        }
        public IViewComponentResult Invoke()
        {
            string currentCulture = Thread.CurrentThread.CurrentUICulture.Name.ToString();
            var languages =  _getAllLanguegeService.Execute().Result;
            @ViewBag.LanList = new SelectList(languages, "Culture", "Name");
            return View(viewName: "LanguageSelect", languages.Where(p=>p.Culture==currentCulture).First());
        }
    }
}
