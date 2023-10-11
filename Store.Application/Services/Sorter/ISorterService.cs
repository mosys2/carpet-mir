using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Sorter
{
    public interface ISorterService
    {
        Task<ResultDto> Execute(Object MyEntity);
    }
    public class SorterService : ISorterService
    {
        private readonly IDatabaseContext _context;
        public SorterService(IDatabaseContext context)
        {
            _context = context;
        }
        
        Task<ResultDto> ISorterService.Execute(object MyEntity)
        {
            throw new NotImplementedException();
        }
    }
}
