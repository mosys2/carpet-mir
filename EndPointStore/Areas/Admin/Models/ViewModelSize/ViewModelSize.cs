using Store.Application.Services.Colors.Commands.AddNewColor;
using Store.Application.Services.Colors.Queries.GetAllColor;
using Store.Application.Services.Sizes.Commands.AddNewSize;
using Store.Application.Services.Sizes.Queries.GetAllSize;

namespace EndPointStore.Areas.Admin.Models.ViewModelSize
{
    public class ViewModelSize
    {
        public List<GetAllSizeDto> GetAllSizes { get; set; }
        public AddNewSizeModel AddNewSizeModel { get; set; }
    }
}
