using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.OrderCarpet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Shapes.Commands.RemoveShape
{
    public interface IRemoveShapeService
    {
        Task<ResultDto> Execute(string IdShape);

    }
    public class RemoveShapeService : IRemoveShapeService
    {
        private readonly IDatabaseContext _context;
        public RemoveShapeService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdShape)
        {
            var shape = await _context.Shapes.FindAsync(IdShape);
            if (shape == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            shape.IsRemoved = true;
            shape.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
