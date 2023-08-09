using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Materials.Queries.GetAllMaterial;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Shapes.Queries.GetAllShape
{
    public interface IGetAllShapeService
    {
        Task<ResultDto<List<GetAllShapeDto>>> Execute();

    }
    public class GetAllShapeService : IGetAllShapeService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllShapeService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto<List<GetAllShapeDto>>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto<List<GetAllShapeDto>>
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var ShapeList = _context.Shapes.Where(q => q.LanguageId == languageId)
               .OrderByDescending(p => p.InsertTime).AsQueryable();
            var Shapes =
            await ShapeList.Where(q => q.IsRemoved == false).Select(r => new GetAllShapeDto
            {
                Id = r.Id,
                Name = r.Name,
            }).ToListAsync();
            return new ResultDto<List<GetAllShapeDto>>
            {
                Data = Shapes,
                IsSuccess = true
            };
        }
    }
    public class GetAllShapeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
