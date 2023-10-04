using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Galleries
{
    public class Gallery:BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public virtual Gallery ParentGallery { get; set; }
        public string? ParentGalleryId { get; set; }  
        public virtual ICollection<Gallery> SubGalleries { get; set; }  
        public virtual ICollection<GalleryItem> GalleryItems { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
    public class GalleryItem:BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public string? Pic { get; set; }
        public string? MinPic { get; set; }
        public string? Alt { get; set; }
        public virtual Gallery Gallery { get; set; }
        public string GalleryId { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
    }
}
