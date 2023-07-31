using Store.Application.Services.ContactsUs.Commands.AddNewContactUsForSite;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;

namespace EndPointStore.Models.ContactUsViewModel
{
    public class ContactUsViewModel
    {
        public ContactUsDto  ContactUsModel { get; set; }
        public GetContactInfoSiteDto GetContactInfoSite { get; set; }
    }
}
