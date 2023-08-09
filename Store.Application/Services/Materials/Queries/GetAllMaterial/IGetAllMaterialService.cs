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

namespace Store.Application.Services.Materials.Queries.GetAllMaterial
{
    public interface IGetAllMaterialService
    {
        Task<ResultDto<List<GetAllMaterialDto>>> Execute();

    }
    public class GetAllMaterialService : IGetAllMaterialService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllMaterialService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto<List<GetAllMaterialDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<GetAllMaterialDto>>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var MaterialList = _context.Materials.Where(q => q.LanguageId == languageId)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            var Materials =
            await MaterialList.Where(q => q.IsRemoved == false).Select(r => new GetAllMaterialDto
            {
                Id = r.Id,
                Name = r.Name,
            }).ToListAsync();
            return new ResultDto<List<GetAllMaterialDto>>
            {
                Data = Materials,
                IsSuccess = true
            };
        }
    }
    public class GetAllMaterialDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
