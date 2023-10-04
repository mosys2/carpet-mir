using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Application.Services.ProductsSite.Commands.AddNewCategory;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Galleries;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Galleries.Commands.AddNewGallery
{
    public interface IAddNewGalleryService
    {
        Task<ResultDto> Execute(RequestGalleryDto requestGalleryDto);
    }
    public class AddNewGalleryService : IAddNewGalleryService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public AddNewGalleryService(IDatabaseContext context, IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public async Task<ResultDto> Execute(RequestGalleryDto requestGalleryDto)
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            }
            if (requestGalleryDto.Id != null)
            {

                var EditList = await _context.Galleries.FindAsync(requestGalleryDto.Id);
                EditList.Name = requestGalleryDto.Name;
                EditList.IsActive = requestGalleryDto.IsActive;
                EditList.ParentGalleryId = requestGalleryDto.ParentId;
                EditList.Description = requestGalleryDto.Description;
                EditList.LanguageId = languageId;
                EditList.UpdateTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                Gallery  gallery= new Gallery()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = requestGalleryDto.Name,
                    Description = requestGalleryDto.Description,      
                    IsActive = requestGalleryDto.IsActive,
                    InsertTime = DateTime.Now,
                    LanguageId = languageId,
                    ParentGallery = GetGalleries(requestGalleryDto.ParentId),
                };
                //Add Gallery
                _context.Galleries.Add(gallery);
              await  _context.SaveChangesAsync();
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageInsert
            };
        }
        private Gallery GetGalleries(string? ParentId)
        {
            return _context.Galleries.Find(ParentId);
        }
    }
   
    public class RequestGalleryDto
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? OrginalName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsEdit { get; set; }
    }
   
}
