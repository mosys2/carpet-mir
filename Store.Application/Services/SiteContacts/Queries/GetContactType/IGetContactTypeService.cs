using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Menu.Queries.IGetMenu;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SiteContacts.Queries.GetContactType
{
    public interface IGetContactTypeService
    {
        Task<List<GetContactTypeDto>> Execute();
    }
    public class GetContactTypeService : IGetContactTypeService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetContactTypeService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<List<GetContactTypeDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id.ToString();
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetContactTypeDto>
                {
                    
                };
            }
            var AllSiteContactTypes = await _context.SiteContactTypes.Where(q=>q.LanguageId==languageId).OrderByDescending(p => p.InsertTime).Select(l => new GetContactTypeDto
            {
                Id = l.Id,
                Name = l.Title,
            }
            ).ToListAsync();
            return AllSiteContactTypes;
        }
    }
    public class GetContactTypeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
