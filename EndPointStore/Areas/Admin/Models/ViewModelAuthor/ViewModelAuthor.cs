using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Commands.AddNewBrand;
using Store.Application.Services.ProductsSite.Queries.GetBrandsList;

namespace EndPointStore.Areas.Admin.Models.ViewModelAuthor
{
    public class ViewModelAuthor
    {
        public List<GetAllAuthorDto> GetAllAuthors { get; set; }
        public AddNewAuthorModel AddNewAuthor { get; set; }
        public List<AllLanguegeDto> AllLangueges { get; set; }
    }
}
