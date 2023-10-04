using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Fainances.Queries.GetRequestPay;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Fainances.Commands.EditRequestPay
{
    public interface IEditRequestPayService
    {
        Task<ResultDto> Execute(string Id, int RefId, string Authority);
    }
    public class EditRequestPayService : IEditRequestPayService
    {
        private readonly IDatabaseContext _context;
        public EditRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string Id, int RefId, string Authority)
        {
            var requestPay =await _context.RequestPays.FindAsync(Id);
            if(requestPay == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message=MessageInUser.NotFind
                };
            }
            requestPay.RefId = RefId;
            requestPay.Authority = Authority;
           await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
            };

        }
    }
}
