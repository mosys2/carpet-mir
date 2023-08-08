using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Authors.Queries.GetAllAuthor;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Colors.Queries.GetAllColor
{
    public interface IGetAllColorService
    {
        Task<ResultDto<List<GetAllColorDto>>> Execute();
    }
    public class GetAllColorService : IGetAllColorService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllColorService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto<List<GetAllColorDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<GetAllColorDto>>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var ColorList = _context.Colors.Where(q => q.LanguageId == languageId)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            var Colors =
            await ColorList.Where(q => q.IsRemoved == false).Select(r => new GetAllColorDto
            {
                Id = r.Id,
                Name = r.Name,
                Value=r.Value
            }).ToListAsync();
            return new ResultDto<List<GetAllColorDto>>
            {
                Data = Colors,
                IsSuccess = true
            };
        }
    }
    public class GetAllColorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Value { get; set; }
    }
}
