using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Visits;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Visits.Commands.AddNewVisit
{
    public interface IAddNewVisitService
    {
       Task<ResultDto> Execute();
    }
    public class AddNewVisitService : IAddNewVisitService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddNewVisitService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ResultDto> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            var visitDay = _context.Visits.OrderByDescending(p => p.Date).FirstOrDefault();
            if (visitDay==null || visitDay.Date.Date != DateTime.Today.Date)
            {
                DateTime now=DateTime.Now;
                PersianCalendar calendar = new PersianCalendar();
                int year = calendar.GetYear(now);
                int month = calendar.GetMonth(now);
                int day=calendar.GetDayOfMonth(now);
                DateTime pdate=Convert.ToDateTime(year+"-"+month+"-"+day).Date;
                Visit visit = new Visit
                {
                    Id=Guid.NewGuid().ToString(),
                    Date = now.Date,
                    PersianDate=pdate,
                    Visited = 1,
                    LanguageId=languageId
                };
                _context.Visits.Add(visit);
                _context.SaveChanges();
            }
            else if (visitDay.Date.Date==DateTime.Today.Date)
            {
                visitDay.Visited++;
                _context.SaveChanges();
            }

            return new ResultDto()
            {
                IsSuccess = true,
            };
        }
    }
}
