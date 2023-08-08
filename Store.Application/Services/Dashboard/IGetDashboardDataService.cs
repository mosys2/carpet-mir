using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using System.Globalization;

namespace Store.Application.Services.Dashboard
{
    public interface IGetDashboardDataService
    {
        Task<DashboardDto> Execute();
    }
    public class GetDashboardDataService : IGetDashboardDataService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetDashboardDataService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<DashboardDto> Execute()
        {
            long todayVisit = 0;
            long weekVisit = 0;
            long monthVisit = 0;
            long sumDWMvisit = 0;
            int userCount = 0;



            var visits = _context.Visits.AsQueryable();
            var users = _context.Users.AsQueryable();
            
            //visit
            todayVisit= visits.Where(p => p.Date.Date==DateTime.Today.Date).FirstOrDefault().Visited;
            weekVisit= visits.Where(p => p.Date.Date<=DateTime.Today.Date && p.Date.Date>=DateTime.Today.AddDays(-7)).Sum(s=>s.Visited);
            monthVisit=visits.Where(p => p.Date.Date<=DateTime.Today.Date && p.Date.Date>=DateTime.Today.AddDays(-30)).Sum(s => s.Visited);
            sumDWMvisit=todayVisit+weekVisit+monthVisit;

            string[] persinTitle = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            int[] months = { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12 };
            List<ShamsiVisitmonth> visitmonths = new List<ShamsiVisitmonth>();

            DateTime oneYearAgo = DateTime.Today.AddYears(-1);
            DateTime startOfMonth = DateTime.Now.AddYears(-1);
            DateTime endOfMonth = DateTime.Now;

            var persianCalendar = CalendarSystem.PersianSimple;
            var dataEntries = _context.Visits
                .Where(entry => entry.Date >= startOfMonth && entry.Date <= endOfMonth)
                .ToList()
                .AsQueryable();
            PersianCalendar pcalendar=new PersianCalendar();
            int i = 0;
            foreach (var month in months)
            {
                long count = dataEntries.Where(p => p.Date.Date.Month==month).Sum(s => s.Visited);
                visitmonths.Add(new ShamsiVisitmonth
                {
                    Count=count,
                    Number=month,
                    Title=persinTitle[i]
                });
                i++;
            }

            //users
            userCount=users.Count();

            return new DashboardDto
            {
                TodayVisit=todayVisit,
                WeekVisit=weekVisit,
                MonthVisit=monthVisit,
                SumDWMvisit=sumDWMvisit,
                UserCount=userCount,
                Visitmonths=visitmonths
            };
        }
    }
    public class DashboardDto
    {
        public long TodayVisit { get; set; }
        public long WeekVisit { get; set; }
        public long MonthVisit { get; set; }
        public long SumDWMvisit { get; set; }
        public int UserCount { get; set; }
        public List<ShamsiVisitmonth>? Visitmonths { get; set; }

    }
    public class ShamsiVisitmonth
    {
        public int Number { get; set; }
        public string? Title { get; set; }
        public long Count { get; set; }
    }
}
