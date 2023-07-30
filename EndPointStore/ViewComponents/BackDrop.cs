using Microsoft.AspNetCore.Mvc;

namespace EndPointStore.ViewComponents
{
    [ViewComponent(Name = "BackDrop")]
    public class BackDrop:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(viewName: "BackDrop");
        }
    }
}
