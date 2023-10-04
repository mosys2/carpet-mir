using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using Store.Domain.Entities.Finances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Fainances.Commands.AddRequestPay
{
    public interface IAddRequestPayService
    {
       Task<ResultDto<ResultRequestPayDto>> Execute(double Amount, string UserId, string CityId);

    }
    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDatabaseContext _context;
        public AddRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<ResultRequestPayDto>> Execute(double Amount, string UserId, string CityId)
        {
            var city =await _context.Provinces.FindAsync(CityId);
            var user =await _context.Users.FindAsync(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount +(city==null?0:(int)city.Cost),
                Id = Guid.NewGuid().ToString(),
                IsPay = false,
                User = user,
                CityId = CityId,
                InsertTime = DateTime.Now,
            };
          await  _context.RequestPays.AddAsync(requestPay);
           await _context.SaveChangesAsync();

            return new ResultDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto
                {
                    Id = requestPay.Id,
                    Amount = requestPay.Amount,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    RequestPayId = requestPay.Id
                },
                IsSuccess = true,
            };
        }
    }
    public class ResultRequestPayDto
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RequestPayId { get; set; }
    }
}
