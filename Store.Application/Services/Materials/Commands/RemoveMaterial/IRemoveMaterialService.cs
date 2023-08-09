using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Materials.Commands.RemoveMaterial
{
    public interface IRemoveMaterialService
    {
        Task<ResultDto> Execute(string IdMaterial);
    }
    public class RemoveMaterialService : IRemoveMaterialService
    {
        private readonly IDatabaseContext _context;
        public RemoveMaterialService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdMaterial)
        {
            var material = await _context.Materials.FindAsync(IdMaterial);
            if (material == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            material.IsRemoved = true;
            material.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = MessageInUser.Delete
            };
        }
    }
}
