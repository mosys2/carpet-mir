using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.ContactsUs.Queries.GetAlarmContactUs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Notification.Queries.GetAllNotification;

namespace EndPointStore.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "Alarm")]
    public class Alarm:ViewComponent
    {
        private readonly IGetAllNotificationService _getGetAllNotificationService;
        public Alarm(IGetAllNotificationService getAllNotificationService)
        {
            _getGetAllNotificationService = getAllNotificationService;
        }
        public IViewComponentResult Invoke()
        {
           
            var Alarms = _getGetAllNotificationService.Execute().Result;
            return View(viewName: "Alarm",Alarms);
        }
    }
}
