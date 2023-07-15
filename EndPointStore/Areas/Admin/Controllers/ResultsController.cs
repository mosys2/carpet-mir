using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Results.Commands.AddNewResult;
using Store.Application.Services.Results.Commands.RemoveResult;
using Store.Application.Services.Results.Queries.GetResult;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResultsController : Controller
    {
        private readonly IAddNewResultService _addNewResultService;
        private readonly IGetResultService _getResultService;
        private readonly IRemoveResultService _removeResultService;
        public ResultsController(IAddNewResultService addNewResultService,
            IGetResultService getResultService,
            IRemoveResultService removeResultService
            )
        {
            _addNewResultService = addNewResultService;
            _getResultService = getResultService;
            _removeResultService = removeResultService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result =await _getResultService.Execute();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RequstResultDto requstResult)
        {
            var resulAdd = await _addNewResultService.Execute(
              new RequstResultDto{
              Id = requstResult.Id,
              CssClass = requstResult.CssClass,
              IsActive = requstResult.IsActive,
              Title = requstResult.Title,
              Image = requstResult.Image,
              Value = requstResult.Value
              }  
              );
            return Json(resulAdd);
        }
        public async Task<IActionResult> Delete(string IdResult)
        {
            var result = await _removeResultService.Execute(IdResult);
            return Json(result);
        }
    }
}
