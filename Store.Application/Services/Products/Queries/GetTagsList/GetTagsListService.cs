using Store.Application.Interfaces.Contexs;
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
        public GetTagsListService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<TagsListDto>> Execute(string? languageId)
        {
            var Tags = _context.Tags.AsQueryable();
            if(!string.IsNullOrEmpty(languageId))
            {
                Tags=Tags.Where(p => p.LanguageId==languageId).AsQueryable();
            }
             var tagList = Tags.Select(t => new TagsListDto
            {
                Id = t.Id,
                Name = t.Name,
                InsertTime = t.InsertTime
            }).ToList().OrderByDescending(r => r.InsertTime).ToList();
            return tagList;
        }
    }
}
