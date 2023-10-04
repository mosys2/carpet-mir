using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ProductsSite.Queries.GetCategory;
using Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Galleries.Queries.GetListGallery
{
    public interface IGetListGalleryService
    {
        Task<ResultDto<List<GalleriesDto>>> Execute(string? Id);
    }
    public class GetListGalleryService : IGetListGalleryService
    {
        private readonly IDatabaseContext _context;
        public GetListGalleryService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<List<GetListGalleryService>>> Execute(string? Id)
        {
            var galleries = _context.Galleries.
                  Include(p => p.ParentGallery)
                  .Include(s => s.SubGalleries).
                  Include(q => q.Language).
                  Where(pp => pp.ParentGalleryId == Id)
                  .ToList().Select(
                 i => new GalleriesDto
                 {
                     Id = i.Id,
                     Name = i.Name,
                     LanguegeId = i.LanguageId,
                     HasChild = i.s.Count > 0 ? true : false,
                     Parent = i.ParentGallery != null ? new ParentGalleryDto
                     {
                         Id = i.ParentGallery.Id,
                         Name = i.ParentGallery.Name
                     } : null
                 }
                 ).ToList();
            return new ResultDto<List<GalleriesDto>>()
            {
                Data = galleries,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };
        }
    }
    public class GalleriesDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LanguegeId { get; set; }
        public bool HasChild { get; set; }
        public ParentGalleryDto Parent { get; set; }
    }
    public class ParentGalleryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
