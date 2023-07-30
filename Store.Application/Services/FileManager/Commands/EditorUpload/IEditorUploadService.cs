using FluentFTP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.FileManager.Commands.EditorUpload
{
	public interface IEditorUploadService
	{
		Task<ResultDto<UploadDataEditor>> Execute(IEnumerable<IFormFile>? files, string? directoryPath);
	}
	public class EditorUploadService : IEditorUploadService
	{
		private readonly IHostingEnvironment _environment;
		private readonly IConfiguration _configuration;
		public EditorUploadService(IHostingEnvironment environment, IConfiguration configuration)
		{
			_configuration = configuration;
			_environment = environment;
		}
		public async Task<ResultDto<UploadDataEditor>> Execute(IEnumerable<IFormFile>? files, string? directoryPath)
		{
			try
			{
				using (var client = new FtpClient())
				{
					string ftpServer = _configuration.GetSection("FtpServer").Value;
					string username = _configuration.GetSection("FtpUsername").Value;
					string password = _configuration.GetSection("FtpPassword").Value;
					string ftpRoot = _configuration.GetSection("FtpEditor").Value;
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
					return new ResultDto<UploadDataEditor>()
					{
						Data=new UploadDataEditor() { Urls=upload },
						IsSuccess = true,
						Message = MessageInUser.UploadSuccess
					};
				}
			}
			catch (Exception)
			{
				return new ResultDto<UploadDataEditor>()
				{

					IsSuccess = true,
					Message = MessageInUser.UploadInvalid
				};
			}
		}
	}
	public class UploadDataEditor
	{
		public List<string>? Urls { get; set; }
	}

}
