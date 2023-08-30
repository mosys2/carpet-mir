using FluentFTP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.Application.Services.FileManager.Commands.UploadFiles
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;
        public UploadFileService(IHostingEnvironment environment, IConfiguration configuration)
        {
            _configuration = configuration;
            _environment = environment;
        }
        public async Task<ResultDto<UploadData>> Execute(IEnumerable<IFormFile>? files, string? directoryPath)
        {
            try
            {
                using (var client = new FtpClient())
                {
                    string ftpServer = _configuration.GetSection("FtpServer").Value;
                    string username = _configuration.GetSection("FtpUsername").Value;
                    string password = _configuration.GetSection("FtpPassword").Value;
                    string ftpRoot = _configuration.GetSection("ftpRoot").Value;
                    ftpRoot="wwwroot/"+ftpRoot;
                    string BaseUrl = _configuration.GetSection("BaseUrl").Value;
                    string url = ftpRoot + directoryPath;
                    client.Host = ftpServer;
                    client.Credentials = new NetworkCredential(username, password);
                    List<string> upload = new List<string>();
                    foreach (var file in files)
                    {
                        string remoteFilePath = url + "/" + file.FileName;
                        using (Stream stream = file.OpenReadStream())
                        {
                            client.UploadStream(stream, remoteFilePath);
                        }
                        upload.Add(BaseUrl+"/"+remoteFilePath);

                    }
                    client.Disconnect();
                    return new ResultDto<UploadData>()
                    {
                        Data=new UploadData() { Urls=upload },
                        IsSuccess = true,
                        Message = MessageInUser.UploadSuccess
                    };
                }
            }
            catch (Exception)
            {
                return new ResultDto<UploadData>()
                {

                    IsSuccess = true,
                    Message = MessageInUser.UploadInvalid
                };
            }
        }

        public async Task<ResultDto<UploadData>> ExecuteSite(IEnumerable<IFormFile>? files)
        {
            try
            {
                using (var client = new FtpClient())
                {
                    string ftpServer = _configuration.GetSection("FtpServer").Value;
                    string username = _configuration.GetSection("FtpUsername").Value;
                    string password = _configuration.GetSection("FtpPassword").Value;
                    string ftpRoot = _configuration.GetSection("ftpRoot").Value;
                    ftpRoot="wwwroot/UserUploads";
                    string BaseUrl = _configuration.GetSection("BaseUrl").Value;
                    string url = ftpRoot;
                    client.Host = ftpServer;
                    client.Credentials = new NetworkCredential(username, password);
                    List<string> upload = new List<string>();

                    foreach (var file in files)
                    {
                        var randomValue = new Random().Next(100000); 
                        var remoteFileName = $"{randomValue}_{file.FileName}";
                        string remoteFilePath = url + "/" + remoteFileName;
                        using (Stream stream = file.OpenReadStream())
                        {
                            client.UploadStream(stream, remoteFilePath);
                        }
                        upload.Add(remoteFileName.ToString());
                    }

                    client.Disconnect();
                    return new ResultDto<UploadData>()
                    {
                        Data=new UploadData() { Urls=upload },
                        IsSuccess = true,
                        Message = MessageInUser.UploadSuccessEn
                    };
                }
            }
            catch (Exception)
            {
                return new ResultDto<UploadData>()
                {

                    IsSuccess = true,
                    Message = MessageInUser.UploadInvalid
                };
            }
        }

        public class UploadData
        {
            public List<string>? Urls { get; set; }
        }
    }
}
