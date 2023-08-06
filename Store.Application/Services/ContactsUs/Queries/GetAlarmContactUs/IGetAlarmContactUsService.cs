using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ContactsUs.Queries.GetAllContactUs;
using Store.Application.Services.Langueges.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.ContactsUs.Queries.GetAlarmContactUs
{
    public interface IGetAlarmContactUsService
    {
        Task<List<GetAlarmContactUsDto>> Execute();

    }
    public class GetAlarmContactUsService : IGetAlarmContactUsService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetAlarmContactUsService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<List<GetAlarmContactUsDto>> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<GetAlarmContactUsDto>
                {

                };
            }
            var ContactUsList =await _context.ContactUs.Where(q => q.LanguageId == languageId&&q.Seen==false)
                          .OrderByDescending(p => p.InsertTime)
                          .Select(p=>new GetAlarmContactUsDto{
                          
                          Id=p.Id,
                          Name=p.Name,
                          Description=p.Text,
                          InsertTime=p.InsertTime.Value.ToString("HH:mm")+" "+((int)(p.InsertTime.Value.Hour)>=12?"عصر":"صبح").ToString(),
                          })
                          .ToListAsync();
            return ContactUsList;
        }
    }

    public class GetAlarmContactUsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string InsertTime { get; set; }

    }
}
