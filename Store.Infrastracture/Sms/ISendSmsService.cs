using Store.Common.Constant;
using Store.Common.Dto;
using System.Net;
namespace Store.Infrastracture.Sms
{
    public interface ISendSmsService
    {
        Task<ResultDto> Execute(SmsDto sms);
    }
    public class SendSmsService : ISendSmsService
    {
        public async Task<ResultDto> Execute(SmsDto sms)
        {
            var client = new WebClient();
            foreach (var phone in sms.ToNum)
            {
                string url = $"http://ippanel.com:8080/?apikey=cShrCoNJRKJPJ1Vsex0zymUzWPWkGmycT_6KzR6rkFQ=&pid={sms.CodePattern}&fnum={sms.FromNum}&tnum={phone}&p1=code&p2=company&v1={sms.Code}&v2={sms.SiteName}";
                var content = client.DownloadString(url);
            }
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.SuccsessSendSSms
            };
        }
        
    }
    public class SmsDto
    {
        public string Code { get; set; }
        public string CodePattern { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FromNum { get; set; }
        public string[] ToNum { get; set; }
        public string? SiteName { get; set; }
    }
}
