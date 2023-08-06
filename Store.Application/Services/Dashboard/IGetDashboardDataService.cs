using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var result = _context.Visits.AsQueryable();
            todayVisit= result.Where(p => p.Date.Date==DateTime.Today.Date).FirstOrDefault().Visited;
            weekVisit= result.Where(p => p.Date.Date<=DateTime.Today.Date && p.Date.Date>=DateTime.Today.AddDays(-7)).Sum(s=>s.Visited);


            return new DashboardDto
            {
                TodayVisit=todayVisit,
                WeekVisit=weekVisit
            };
        }
    }
    public class DashboardDto
    {
        public long TodayVisit { get; set; }
        public long WeekVisit { get; set; }
    }
}
