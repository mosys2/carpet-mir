using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Langueges.Queries;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "LanguegeSelect")]
    public class LanguegeSelect:ViewComponent
    {
        private readonly IGetAllLanguegeService _getAllLanguegeService;
        public LanguegeSelect(IGetAllLanguegeService getAllLanguegeService)
        {
            _getAllLanguegeService = getAllLanguegeService;
        }
        public IViewComponentResult Invoke()
        {
            string currentCulture = Thread.CurrentThread.CurrentUICulture.Name.ToString();
            var languages = _getAllLanguegeService.Execute().Result;
            @ViewBag.LanList = languages;
            return View(viewName: "LanguegeSelect", languages.Where(p => p.Culture == currentCulture).First());
        }
    }
}
