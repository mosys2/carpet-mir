using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SiteContacts.Queries.GetContactInfoForSite;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Queries.GetAllPagesForSite
{
    public interface IGetAllPagesSiteService
    {
        Task<List<GetAllPagesSiteDto>> Execute();
    }
    public class GetAllPagesSiteService : IGetAllPagesSiteService
    {

        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllPagesSiteService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<GetAllPagesSiteDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetAllPagesSiteDto>
                {

                };
            }
            var pages = _context.PageCreators.Where(q => q.LanguageId == languageId && q.IsRemoved == false && q.IsActive)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
           var listPages=await pages.Select(w => new GetAllPagesSiteDto
            {
                Content = w.Content,
            }).ToListAsync();
            return listPages;
        }
    }
    public class GetAllPagesSiteDto
    {
        public string? Content { get; set; }
    }
}
