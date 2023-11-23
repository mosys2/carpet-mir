using Microsoft.AspNetCore.Http;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Store.Application.Services.FileManager.Commands.UploadFiles.UploadFileService;

namespace Store.Application.Services.FileManager.Commands.UploadFiles
{
	public interface IUploadFileService
	{
		Task<ResultDto<UploadData>> Execute(IEnumerable<IFormFile>? files, string? directoryPath);
        Task<ResultDto<UploadData>> ExecuteSite(IEnumerable<IFormFile>? files);
        Task<ResultDto> FetchImageAndUpload(SaveToFtpDto reque);
    }
}
