using Microsoft.Extensions.Configuration;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.Langueges.Queries;
using Store.Common.Constant.NoImage;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Galleries.Queries.GetParentAndSubGallery
{
    public interface IGetParentAndSubGalleryService
    {
        Task<List<ParentAndSubGalleryDto>> Execute();
    }
    public class GetParentAndSubGalleryService : IGetParentAndSubGalleryService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;

        public GetParentAndSubGalleryService(IDatabaseContext context,
            IGetSelectedLanguageServices language)
        {
            _context = context;
            _language = language;
        }
        public static List<ParentAndSubGalleryDto> Gallery = new List<ParentAndSubGalleryDto>();
        public static List<ParentAndSubGalleryDto> AllGallery = new List<ParentAndSubGalleryDto>();
        public async Task<List<ParentAndSubGalleryDto>> Execute()
        {
            Gallery.Clear();
            AllGallery.Clear();
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new List<ParentAndSubGalleryDto>
                {
                };
            }
            var listGallery = _context.Galleries.Where(p => p.LanguageId == languageId)
             .Select(e => new ParentAndSubGalleryDto()
             {
                 Id = e.Id,
                 Name = e.Name,
                 ParentId = e.ParentGalleryId,
                 InsertTime = e.InsertTime,
                 IsActive = e.IsActive,
                 Description = e.Description,
                 OrginallName = e.Name,
             }
             ).OrderByDescending(p => p.InsertTime).ToList();

            AllGallery.AddRange(listGallery);

            foreach (var item in listGallery.Where(e => e.ParentId == null))
            {
                int level = 1;
                Gallery.Add(new ParentAndSubGalleryDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    ParentId = item.ParentId,
                    ParentName = "اصلی",
                    IsActive = item.IsActive,
                    Description = item.Description,
                    OrginallName = item.Name,
                });
                var child = listGallery.Where(y => y.ParentId == item.Id).ToList();
                listGenerator(child, level);
            }
            return Gallery;
        }
        public void listGenerator(List<ParentAndSubGalleryDto> selectList, int level)
        {
            level++;
            foreach (var itemChild in selectList)
            {
                var childN = AllGallery.Where(p => p.ParentId == itemChild.Id).ToList();
                if (childN.Any())
                {
                    Gallery.Add(new ParentAndSubGalleryDto()

                    {
                        Id = itemChild.Id,
                        Name = GetDashCount(level) + " " + itemChild.Name,
                        ParentId = itemChild.ParentId,
                        ParentName = AllGallery.Where(t => t.Id == itemChild.ParentId).FirstOrDefault()?.Name,
                        IsActive = itemChild.IsActive,
                        Description = itemChild.Description,
                        OrginallName = itemChild.Name,
                    });
                    listGenerator(childN, level);
                }
                else
                {
                    Gallery.Add(new ParentAndSubGalleryDto()
                    {
                        Id = itemChild.Id,
                        Name = GetDashCount(level) + " " + itemChild.Name,
                        ParentId = itemChild.ParentId,
                        ParentName = AllGallery.Where(t => t.Id == itemChild.ParentId).FirstOrDefault()?.Name,
                        IsActive = itemChild.IsActive,
                        Description = itemChild.Description,
                        OrginallName = itemChild.Name,
                    });
                }
            }
            return;
        }
        public string GetDashCount(int level)
        {
            string dash = "";
            for (int i = 1; i < level; i++)
            {
                dash += "- ";
            }
            return dash;
        }
    }
    public class ParentAndSubGalleryDto
    {
        public string? Id { get; set; }
        public string? OrginallName { get; set; }
        public string? Name { get; set; }
        public string? ParentId { get; set; }
        public string? ParentName { get; set; }
        public DateTime? InsertTime { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
    }
}
