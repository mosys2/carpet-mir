using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "HeaderTop")]
    public class HeaderTop:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(viewName: "HeaderTop");
        }
    }
}
