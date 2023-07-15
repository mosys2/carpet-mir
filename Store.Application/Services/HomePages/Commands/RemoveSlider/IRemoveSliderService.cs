using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePages.Commands.RemoveSlider
{
    public interface IRemoveSliderService
    {
        Task<ResultDto> Execute(string IdSlider);
    }
    public class RemoveSliderService : IRemoveSliderService
    {
        private readonly IDatabaseContext _context;
        public RemoveSliderService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string IdSlider)
        {
            var slider =await _context.Sliders.FindAsync(IdSlider);
            if(slider == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "اسلایدری یافت نشد!"
                };
            }
            slider.IsRemoved = true;
            slider.RemoveTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = false,
                Message = MessageInUser.RemoveSlider
            };
        }
    }
}
