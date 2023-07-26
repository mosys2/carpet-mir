using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;

namespace Store.Application.Services.ProductsSite.Queries.GetCategoryForSite
{
    public class GetCategorySiteService : IGetCategorySiteService
    {
        private readonly IDatabaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly IGetSelectedLanguageServices _language;
        public GetCategorySiteService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _language = languege;
        }

        public async Task<List<CategorySiteDto>> Execute()
        {
            //string languageId = _language.Execute().Result.Data.Id ?? "";
            //if (string.IsNullOrEmpty(languageId))
            //{
            //    return new List<ParentCategoryDto>
            //    {
            //    };
            //}
            string BaseUrl = _configuration.GetSection("BaseUrl").Value;
            var ParentListQuery = _context.Category.Include(s => s.SubCategories).Where(r => r.ParentCategoryId == null).AsQueryable();
            var ParentList = ParentListQuery.Select(
                e => new CategorySiteDto
                {
                    Name = e.Name,
                    Id = e.Id,
                    Image=BaseUrl+e.Icon,
                    Description= e.Description,
                    Child=e.SubCategories.ToList().Select(w=>new SubCategorySitDto{NameChild=w.Name,ParenId=w.ParentCategoryId }).ToList()
                }
                );
            return ParentList.ToList();
        }
    }
}
