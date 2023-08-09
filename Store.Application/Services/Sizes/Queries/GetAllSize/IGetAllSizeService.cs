using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Colors.Queries.GetAllColor;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Sizes.Queries.GetAllSize
{
    public interface IGetAllSizeService
    {
        Task<ResultDto<List<GetAllSizeDto>>> Execute();
    }
    public class GetAllSizeService : IGetAllSizeService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllSizeService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto<List<GetAllSizeDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<GetAllSizeDto>>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var SizesList = _context.Sizes.Where(q => q.LanguageId == languageId)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            var Sizes =
            await SizesList.Where(q => q.IsRemoved == false).Select(r => new GetAllSizeDto
            {
                Id = r.Id,
                Width = r.Width,
                Height = r.Height,
                Lenght=r.Lenght,
                Meterage=(r.Width*r.Lenght).ToString()+"متر",
            }).ToListAsync();
            return new ResultDto<List<GetAllSizeDto>>
            {
                Data = Sizes,
                IsSuccess = true
            };
        }
    }
    public class GetAllSizeDto
    {
        public string Id { get; set; }
        public int? Width { get; set; }
        public int? Lenght { get; set; }
        public int? Height { get; set; }
        public string? Meterage { get; set; }
    }
}
