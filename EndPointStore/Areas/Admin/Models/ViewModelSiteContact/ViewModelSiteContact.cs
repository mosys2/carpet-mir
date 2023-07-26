using Store.Application.Services.HomePages.Queries.GetSlider;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Commands.AddNewProduct;
using Store.Application.Services.SiteContacts.Commands.AddNewSiteContact;
using Store.Application.Services.SiteContacts.Queries.GetAllSiteContact;

namespace EndPointStore.Areas.Admin.Models.ViewModelSiteContact
{
    public class ViewModelSiteContact
    {
        public AddNewSiteContactModel AddNewSiteContact { get; set; }
        public List<GetAllSiteContactDto> GetAllSiteContacts { get; set; }

        //public List<ListSliderDto> ListSliders { get; set; }
        //public List<AllLanguegeDto> AllLangueges { get; set; }
    }
}
