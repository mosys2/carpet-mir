using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Fainances.Queries.GetRequestPay
{
    public interface IGetRequestPayService
    {
       Task<ResultDto<RequestPayDto>> Execute(string Id);

    }
    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDatabaseContext _context;
        public GetRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<RequestPayDto>> Execute(string Id)
        {
            var requestPay = _context.RequestPays.Where(p => p.Id == Id).FirstOrDefault();
            if (requestPay != null)
            {
                return new ResultDto<RequestPayDto>()
                {
                    Data = new RequestPayDto
                    {
                        Amount = requestPay.Amount,
                        Id = requestPay.Id,
                    },
                    IsSuccess = true,
                };
            }
            else
            {
                throw new Exception("request not found");
            }
        }
    }
    public class RequestPayDto
    {
        public string Id { get; set; }
        public double Amount { get; set; }
    }
}
