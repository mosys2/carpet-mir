using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Colors.Commands.AddNewColor;
using Store.Application.Services.Colors.Queries.GetAllColor;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Sizes.Commands.AddNewSize;

namespace EndPointStore.Areas.Admin.Models.ViewModelColor
{
    public class ViewModelColor
    {
        public List<GetAllColorDto> GetAllColors { get; set; }
        public AddNewColorModel AddNewColorModel { get; set; }
    }
}
