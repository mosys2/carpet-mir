using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.RemoveRegisterCustomCarpet
{
    public interface IRemoveRegisterCustomCarpetService
    {
        Task<ResultDto> Execute(string registerId);
    }
    public class RemoveRegisterCustomCarpetService : IRemoveRegisterCustomCarpetService
    {
        private readonly IDatabaseContext _context;

        public RemoveRegisterCustomCarpetService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string registerId)
        {
            var registerCarpet =await _context.RegisterCarpets.FindAsync(registerId);
            if (registerCarpet == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            registerCarpet.IsRemoved=true;
            registerCarpet.RemoveTime=DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
