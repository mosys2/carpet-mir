using EndPointStore.Areas.Admin.Models.ViewModelMaterial;
using EndPointStore.Areas.Admin.Models.ViewModelShape;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Materials.Commands.AddNewMaterial;
using Store.Application.Services.Shapes.Commands.AddNewShape;
using Store.Application.Services.Shapes.Commands.RemoveShape;
using Store.Application.Services.Shapes.Queries.GetAllShape;
using Store.Common.Constant;
using Store.Common.Dto;

namespace EndPointStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShapesController : Controller
    {
        private readonly IAddNewShapeService _addNewShapeService;
        private readonly IGetAllShapeService _getAllShapeService;
        private readonly IRemoveShapeService _removeShapeService;
        public ShapesController(IAddNewShapeService addNewShapeService,
            IRemoveShapeService removeShapeService,
            IGetAllShapeService getAllShapeService)
        {
            _addNewShapeService = addNewShapeService;
            _getAllShapeService= getAllShapeService;
            _removeShapeService= removeShapeService;
        }
        public async Task<IActionResult> Index()
        {
            var listShape = await _getAllShapeService.Execute();
            ViewModelShape viewModelShapes = new ViewModelShape()
            {
                AddNewShapeModel = new AddNewShapeModel(),
                GetAllShapes = listShape.Data,
            };
            return View(viewModelShapes);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddNewShapeModel addNewShape)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _addNewShapeService.Execute(new AddNewShape
            {
                Id = addNewShape.Id,
                Name = addNewShape.Name,
            });
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string shapeId)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.IsValidForm
                });
            }
            var result = await _removeShapeService.Execute(shapeId);
            return Json(result);
        }
    }
}
