
using QRCoder;
using Store.Common.Dto;
using System.Drawing;
using System.Drawing.Imaging;

namespace Store.Application.Services.QRCoder
{
    public interface IQRService
    {
        Task<ResultDto<String>> GetQR(string data, int size);
    }
    public class QRService : IQRService
    {
        public async Task<ResultDto<String>> GetQR(string data, int size)
        {
            string QRImg = "";
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                using (Bitmap obitmap = qrCode.GetGraphic(20))
                {
                     obitmap.Save(ms, ImageFormat.Png);
                    QRImg="data:image/jpeg;base64,"+Convert.ToBase64String(ms.ToArray());
                }
            }
            return new ResultDto<string>
            {
                Data= QRImg,
                IsSuccess=true,
            };

        }
    }
}
