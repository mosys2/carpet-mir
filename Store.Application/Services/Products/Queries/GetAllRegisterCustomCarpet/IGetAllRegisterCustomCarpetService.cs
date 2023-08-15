using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ContactsUs.Queries.GetAllContactUs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.Products.Queries.GetAllCategoryFeature;
using Store.Common;
using Store.Domain.Entities.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Queries.GetAllRegisterCustomCarpet
{
    public interface IGetAllRegisterCustomCarpetService
    {
        Task<ResultGetRegisterCustomCarpetDto> Execute(RequestGetRegisterCustomCarpetDto requestGetRegister );
    }
    public class GetAllRegisterCustomCarpetService: IGetAllRegisterCustomCarpetService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAllRegisterCustomCarpetService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }

        public async Task<ResultGetRegisterCustomCarpetDto> Execute(RequestGetRegisterCustomCarpetDto requestGetRegister)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultGetRegisterCustomCarpetDto
                {
                    
                };
            }
            var RegisterCustom = _context.RegisterCarpets
                .Where(w => w.LanguageId == languageId && w.IsRemoved == false)
               .OrderByDescending(t => t.InsertTime).AsQueryable();
            if (!string.IsNullOrEmpty(requestGetRegister.SearchKey))
            {
                requestGetRegister.SearchKey = requestGetRegister.SearchKey.Replace("-", " ");
                RegisterCustom =RegisterCustom.Where(l => l.Name.Contains(requestGetRegister.SearchKey) || l.Country.Contains(requestGetRegister.SearchKey) || l.PhoneNumber.Contains(requestGetRegister.SearchKey));
            }
            int RowsCount = 0;
           var RegisterCustomList=RegisterCustom.Select(e => new GetAllRegisterCustomCarpetDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Country = e.Country,
                    InsertTime=e.InsertTime,
                    Seen=e.Seen
                }
                ).ToPaged(requestGetRegister.Page, requestGetRegister.PageSize, out RowsCount).ToList();
            return new ResultGetRegisterCustomCarpetDto()
            {
                GetAllRegisterCustomCarpets = RegisterCustomList,
                Rows = RowsCount,
                Pageinate = Pagination.PaginateAdmin(requestGetRegister.Page, requestGetRegister.PageSize, RowsCount, "RegisterCarpet", requestGetRegister.SearchKey),
            };
        }
    }
    public class ResultGetRegisterCustomCarpetDto
    {
        public List<GetAllRegisterCustomCarpetDto> GetAllRegisterCustomCarpets { get; set; }
        public long Rows;
        public string? Pageinate { get; set; }
    }
    public class RequestGetRegisterCustomCarpetDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchKey { get; set; }
    }
    public class GetAllRegisterCustomCarpetDto
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public bool Seen { get; set; }
        public string? Country { get; set; }
        public DateTime? InsertTime { get; set; }
    }
}
