using Org.BouncyCastle.Asn1.Ocsp;
using Store.Application.Services.Visits.Commands.AddNewVisit;

namespace EndPointStore.Areas.Admin.Utilities
{
    [Microsoft.AspNetCore.Mvc.Area("Admin")]
    public class VisitUtility
    {
        private readonly RequestDelegate _requestDelegate;

        public VisitUtility(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;

        }
        public async Task InvokeAsync(HttpContext context, IAddNewVisitService addNewVisit)
        {
            string visitorId = context.Request.Cookies["visitorId"]?? "";
            if (string.IsNullOrEmpty(visitorId))
            {
                context.Response.Cookies.Append("visitorId", Guid.NewGuid().ToString(), new CookieOptions()
                {
                    HttpOnly = true,
                    Secure = false,
                    Expires = DateTime.Now.Date.AddDays(1),
                });
                
                string? agent = context.Request.Headers.UserAgent.ToString();
                string? ip= context.Connection.RemoteIpAddress?.ToString();
                await addNewVisit.Execute(agent,ip);
            }
            await _requestDelegate(context);
        }
    }
}
