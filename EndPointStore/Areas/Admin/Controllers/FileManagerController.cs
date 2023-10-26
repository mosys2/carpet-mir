using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.FileManager.Commands.CreateDirectory;
using Store.Application.Services.FileManager.Commands.EditorUpload;
using Store.Application.Services.FileManager.Commands.RemoveFiles;
using Store.Application.Services.FileManager.Commands.UploadFiles;
using Store.Application.Services.FileManager.Queries.ListDirectory;
using Store.Common.Constant;
using Store.Common.Dto;
using static Store.Application.Services.FileManager.Commands.UploadFiles.UploadFileService;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FileManagerController : Controller
    {
        private readonly IFileDirectoryService _fileDirectoryService;
        private readonly ICreateDirectory _createDirectory;
		private readonly IUploadFileService _uploadFileService;
        private readonly IEditorUploadService _editorUpload;
		private readonly IRemoveFilesOrDirectoriesService _removeFilesOrDirectoriesService;
		public FileManagerController(IFileDirectoryService fileDirectoryService, 
            ICreateDirectory createDirectory, 
            IUploadFileService uploadFileService,
			IEditorUploadService editorUpload,
			IRemoveFilesOrDirectoriesService removeFilesOrDirectoriesService)
        {
            _fileDirectoryService = fileDirectoryService;
            _createDirectory = createDirectory;
            _uploadFileService = uploadFileService;
            _editorUpload=editorUpload;
            _removeFilesOrDirectoriesService = removeFilesOrDirectoriesService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
	    [HttpPost]
        public async Task<IActionResult> GetDirectoryList(GetDirectoryModel model)
        {
            var files = await _fileDirectoryService.GetFilesAsync(model.Directory);
            return Json(new ResultDto<List<FileItem>>
            { Data=files,
            IsSuccess=true
            }
            );
        }
		[HttpPost]
		public async Task<IActionResult> CreateDirectory(CreateDirectoryModel createDirectory)
		{
			var files = await _createDirectory.Execute(createDirectory.Directory, createDirectory.Name);
			return Json(files);
		}
		[HttpPost]
		public async Task<IActionResult> UploadFiles(IEnumerable<IFormFile> Files,string Directory)
		{
            var result =await  _uploadFileService.Execute(Files, Directory);
            return Json(result);
		}
		[HttpPost]
		public async Task<IActionResult> EditorUploadFiles(IEnumerable<IFormFile> Files, string Directory)
		{
			var result = await _editorUpload.Execute(Files, Directory);
			return Json(result);
		}
		[HttpPost]
		public async Task<IActionResult> RemoveFiles(RemoveFilesModel removeFiles)
		{
			var result = await _removeFilesOrDirectoriesService.Execute(removeFiles.ArryRemoveItem, removeFiles.Directory);
			return Json(result);
		}

        [HttpPost]
        public async Task<IActionResult> SaveToFtp(SaveToFtpDto model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return  Json(new ResultDto
            //    {
            //        IsSuccess = false,
            //        Message=MessageInUser.UploadInvalid
            //    });
            //}
            var response=await _uploadFileService.FetchImageAndUpload(model);
            return Json(response);
        }
	}
    public class GetDirectoryModel
    {
        public string? Directory { get; set; }
    }
	public class CreateDirectoryModel
	{
		public string? Directory { get; set; }
        public string? Name { get; set; }
    }
	public class RemoveFilesModel
	{
        public List<string>? ArryRemoveItem { get; set; }
		public string? Directory { get; set; }
	}
}
