using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.ContactsUs.Queries.GetAlarmContactUs;
using Store.Application.Services.Langueges.Queries;

namespace EndPointStore.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "Alarm")]
    public class Alarm:ViewComponent
    {
        private readonly IGetAlarmContactUsService _getAlarmContactUsService;
        public Alarm(IGetAlarmContactUsService getAlarmContactUsService)
        {
            _getAlarmContactUsService = getAlarmContactUsService;
        }
        public IViewComponentResult Invoke()
        {
           
            var Alarms = _getAlarmContactUsService.Execute().Result;
            return View(viewName: "Alarm",Alarms);
        }
    }
}
