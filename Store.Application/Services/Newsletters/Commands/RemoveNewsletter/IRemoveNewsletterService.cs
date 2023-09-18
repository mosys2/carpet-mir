using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Newsletters.Queries.GetAllNewsletter;
using Store.Application.Services.SettingsSite.Queries;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Newsletters.Commands.RemoveNewsletter
{
    public interface IRemoveNewsletterService
    {
        Task<ResultDto> Execute(string Id);
    }
    public class RemoveNewsletterService : IRemoveNewsletterService
    {
        private readonly IDatabaseContext _context;
        public RemoveNewsletterService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string Id)
        {
            
            var result =await _context.Newsletters.FindAsync(Id);
            if(result==null)
            {
                return new ResultDto{ IsSuccess=false,Message=MessageInUser.NotFind};
            }
            result.IsRemoved = true;
            result.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto { IsSuccess=true,Message=MessageInUser.Remove} ;

        }
    }
}
