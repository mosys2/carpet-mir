using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Langueges.Queries
{
    public interface IGetAllLanguegeService
    {
        Task<List<AllLanguegeDto>> Execute();
    }
    public class GetAllLanguegeService : IGetAllLanguegeService
    {
        private readonly IDatabaseContext _context;
        public GetAllLanguegeService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<AllLanguegeDto>> Execute()
        {
            var AllLanguege =await _context.Languages.OrderByDescending(p=>p.InsertTime).Select(l => new AllLanguegeDto
            {
                Id = l.Id,
                Name = l.Name,
                
            }
            ).ToListAsync();
            return AllLanguege;
        }
    }
    public class AllLanguegeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }

    }
}
