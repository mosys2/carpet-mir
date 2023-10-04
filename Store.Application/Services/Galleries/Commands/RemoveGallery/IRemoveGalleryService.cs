using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ProductsSite.Commands.DeleteCategory;
using Store.Common.Constant;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Galleries.Commands.RemoveGallery
{
    public interface IRemoveGalleryService
    {
        Task<ResultDto> Execute(string Id);
    }
    public class RemoveGalleryService : IRemoveGalleryService
    {
        private readonly IDatabaseContext _context;
        public RemoveGalleryService(IDatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        public static List<DeleteListGalleryDto> Gallery = new List<DeleteListGalleryDto>();
        public static List<DeleteListGalleryDto> AllGallery = new List<DeleteListGalleryDto>();
        public async Task<ResultDto> Execute(string Id)
        {
            Gallery.Clear();
            AllGallery.Clear();
            var listGallery = await _context.Galleries.Select
                (
                e => new DeleteListGalleryDto()
                {
                    Id = e.Id,
                    ParentId = e.ParentGalleryId,
                }
                ).ToListAsync();

            AllGallery.AddRange(listGallery);

            foreach (var item in listGallery.Where(e => e.Id == Id))
            {
                int level = 1;
                Gallery.Add(new DeleteListGalleryDto()
                {
                    Id = item.Id,
                    ParentId = item.ParentId,
                });
                var child = listGallery.Where(y => y.ParentId == item.Id).ToList();
                listGenerator(child, level);
            }
            foreach (var remove in Gallery)
            {
                var ItemRemove = _context.Galleries.Where(r => r.Id == remove.Id).FirstOrDefault();
                if (ItemRemove != null)
                {
                    ItemRemove.IsRemoved = true;
                    ItemRemove.RemoveTime = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }
            //Show Result
            return new ResultDto()
            {
                IsSuccess = true,
                Message = MessageInUser.MessageDelete
            };
        }
        public void listGenerator(List<DeleteListGalleryDto> selectList, int level)
        {
            level++;
            foreach (var itemChild in selectList)
            {
                var childN = AllGallery.Where(p => p.ParentId == itemChild.Id).ToList();
                if (childN.Any())
                {
                    Gallery.Add(new DeleteListGalleryDto()

                    {
                        Id = itemChild.Id,
                        ParentId = itemChild.ParentId,
                    });
                    listGenerator(childN, level);
                }
                else
                {
                    Gallery.Add(new DeleteListGalleryDto()
                    {
                        Id = itemChild.Id,
                        ParentId = itemChild.ParentId,
                    });
                }
            }
            return;
        }
    }
    public class DeleteListGalleryDto
    {
        public bool IsRemove { get; set; }
        public DateTime? RemoveTime { get; set; }
        public string? Id { get; set; }
        public string? ParentId { get; set; }
    }
}
