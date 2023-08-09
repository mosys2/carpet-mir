using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Carts;
using Store.Application.Services.Posts.Queries;
using System.Xml.Linq;
using Store.Application.Services.SettingsSite.Queries;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "Metatag")]
    public class Metatag : ViewComponent
    {
        private readonly IGetSettingServices _getSettingServices;
        public Metatag(IGetSettingServices getSettingServices)
        {
            _getSettingServices=getSettingServices;
        }
        public IViewComponentResult Invoke(string Title)
        {
            ViewBag.Metatag = _getSettingServices.Execute();
            return View(viewName: "Metatag");
        }
    }
}
