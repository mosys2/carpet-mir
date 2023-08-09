using Store.Application.Services.Materials.Queries.GetAllMaterial;
using Store.Application.Services.Shapes.Commands.AddNewShape;
using Store.Application.Services.Shapes.Queries.GetAllShape;

namespace EndPointStore.Areas.Admin.Models.ViewModelShape
{
    public class ViewModelShape
    {
        public List<GetAllShapeDto> GetAllShapes { get; set; }
        public AddNewShapeModel AddNewShapeModel { get; set; }
    }
}
