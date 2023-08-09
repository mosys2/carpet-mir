using Store.Application.Services.Colors.Commands.AddNewColor;
using Store.Application.Services.Colors.Queries.GetAllColor;
using Store.Application.Services.Materials.Commands.AddNewMaterial;
using Store.Application.Services.Materials.Queries.GetAllMaterial;

namespace EndPointStore.Areas.Admin.Models.ViewModelMaterial
{
    public class ViewModelMaterial
    {
        public List<GetAllMaterialDto> GetAllMaterials { get; set; }
        public AddNewMaterialModel AddNewMaterialModel { get; set; }
    }
}
