using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;

namespace EndPointStore.Areas.Admin.Models.ViewModelSlider
{
    public class ViewModelSlider
    {
        public List<ListSliderDto> ListSliders { get; set; }
        public List<AllLanguegeDto> AllLangueges { get; set; }


    }
}
