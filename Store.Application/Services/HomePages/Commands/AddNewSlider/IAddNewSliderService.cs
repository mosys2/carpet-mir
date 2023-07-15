using Store.Application.Interfaces.Contexs;
using Store.Common.Dto;
using Store.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePages.Commands.AddNewSlider
{
    public interface IAddNewSliderService
    {
        Task<ResultDto> Execute(RequstSliderDto requstSliderDto);
    }
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IDatabaseContext _context;
        public AddNewSliderService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequstSliderDto requstSliderDto)
        {
            if (requstSliderDto.Id != null)
            {
                var slidrEdit =await _context.Sliders.FindAsync(requstSliderDto.Id);
                slidrEdit.Title = requstSliderDto.Title;
                slidrEdit.Description= requstSliderDto.Description;
                slidrEdit.Link = requstSliderDto.Link;
                slidrEdit.IsActive = requstSliderDto.IsActive;
                slidrEdit.UrlImage= requstSliderDto.UrlImage;
                slidrEdit.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "موفق"
                };
            }
            Slider slider = new Slider()
            {
                Id = Guid.NewGuid().ToString(),
                Title = requstSliderDto.Title,
                Description = requstSliderDto.Description,
                Link = requstSliderDto.Link,
                IsActive=requstSliderDto.IsActive,
                UrlImage = requstSliderDto.UrlImage,
                InsertTime = DateTime.Now,
            };
            _context.Sliders.Add(slider);
            await _context.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess=true,
                Message="موفق"
            };
        }
    }
    public class RequstSliderDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public string UrlImage { get; set; }
    }
}
