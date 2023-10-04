using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Pages.Queries.GetAllPagesForSite;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Groups.Queries.GetItemGroup
{
    public interface IGetItemGroupService
    {
        Task<ResultDto<List<GetItemGroupDto>>> Execute();
    }
    public class GetItemGroupService : IGetItemGroupService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetItemGroupService(IDatabaseContext context,
            IGetSelectedLanguageServices languege,
            IConfiguration configuration)
        {
            _context = context;
            _language = languege;

        }
        public async Task<ResultDto<List<GetItemGroupDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<GetItemGroupDto>>
                {
                    IsSuccess=false
                };
            }
            var itemGroups =await _context.GroupItems
                .Where(l=>l.LanguageId==languageId)
                 .Select(i => new GetItemGroupDto
                 {
                     Id = i.Id,
                     Name = i.Title
                 }).ToListAsync();
            return new ResultDto<List<GetItemGroupDto>>
            {
                IsSuccess = true,
                Data = itemGroups
            };
        }
    }
    public class GetItemGroupDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
    }
}
