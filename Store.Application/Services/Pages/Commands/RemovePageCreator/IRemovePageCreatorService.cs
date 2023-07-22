using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Pages.Commands.RemovePageCreator
{
    public interface IRemovePageCreatorService
    {
        Task<ResultDto> Execute(string pageId);
    }
    public class RemovePageCreatorService : IRemovePageCreatorService
    {
        private readonly IDatabaseContext _context;
        public RemovePageCreatorService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string pageId)
        {
            var removePage =await _context.PageCreators.FindAsync(pageId);
            if (removePage == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind,
                };
            }
            removePage.IsRemoved=true;
            removePage.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }

}
