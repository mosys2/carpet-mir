using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Langueges.Queries
{
    public interface IGetSelectedLanguageServices
    {
        Task<ResultDto<SelectedLanguageDto>> Execute();
    }
    public class GetSelectedLanguageServices : IGetSelectedLanguageServices
    {
        private readonly IDatabaseContext _context;
        public GetSelectedLanguageServices(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<SelectedLanguageDto>> Execute()
        {
            string currentCulture = Thread.CurrentThread.CurrentUICulture.Name.ToString();
            var lang = _context.Languages
                .Where(p => p.Culture==currentCulture)
                .FirstOrDefault();
            if(lang==null)
            {
                return new ResultDto<SelectedLanguageDto>()
                {
                   IsSuccess=false,
                   Message=MessageInUser.NotFind
                };
            }
            return new ResultDto<SelectedLanguageDto>()
            {
                Data=new SelectedLanguageDto()
                {
                    Id=lang.Id,
                    Culture=lang.Culture
                },
                IsSuccess=true,
            };
        }
    }
    public class SelectedLanguageDto
    {
        public string? Id { get; set; }
        public string? Culture { get; set; }
    }
}
