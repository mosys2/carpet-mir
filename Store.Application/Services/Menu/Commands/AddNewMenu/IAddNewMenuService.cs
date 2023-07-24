using Newtonsoft.Json;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Menu.Queries.IGetMenu;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Menu.Commands.AddNewMenu
{
    public interface IAddNewMenuService
    {
        Task<ResultDto> Execute(List<MenuItemDto> model, string Id);
    }
    public class AddNewMenuService : IAddNewMenuService
    {
        private readonly IDatabaseContext _context;
        public AddNewMenuService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(List<MenuItemDto> model, string Id)
        {

            var editMenu =await _context.Settings.FindAsync(Id);
            if(editMenu == null)
            {
                return new ResultDto()
                {
                    IsSuccess=false,
                    Message=MessageInUser.NotFind
                };
            }
            var jsonSeri = JsonConvert.SerializeObject(model);
            editMenu.Menu=jsonSeri;
            await  _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert,
            };
        }
    }
}
