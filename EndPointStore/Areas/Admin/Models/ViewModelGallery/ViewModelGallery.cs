using Store.Application.Services.Galleries.Commands.AddNewGallery;
using Store.Application.Services.Galleries.Queries.GetListGallery;
using Store.Application.Services.Galleries.Queries.GetParentAndSubGallery;

namespace EndPointStore.Areas.Admin.Models.ViewModelGallery
{
    public class ViewModelGallery
    {
        public AddNewGallery AddNewGallery { get; set; }
        public List<ParentAndSubGalleryDto> Galleries { get; set; }
    }
}
