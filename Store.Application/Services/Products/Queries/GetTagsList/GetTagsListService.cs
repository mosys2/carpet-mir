using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ProductsSite.Queries.GetTagsList
{
    public class GetTagsListService : IGetTagsListService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetTagsListService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<List<TagsListDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<TagsListDto>
                {
                };
            }
            var Tags = _context.Tags.Where(p => p.LanguageId==languageId).Select(t => new TagsListDto
            {
                Id = t.Id,
                Name = t.Name,
                InsertTime = t.InsertTime
            }).ToList().OrderByDescending(r => r.InsertTime).ToList();
            return Tags;
        }
    }
}
