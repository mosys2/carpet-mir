using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.AddNewFeatureToCategory
{
    public interface IAddNewFeatureToCategoryService
    {
    }
    public class AddNewFeatureToCategoryModel
    {
        [Required]
        public string Id { get; set; }
        public string? ShapeId { get; set; }
        public string? SizeId { get; set; }
        public string? MaterialId { get; set; }
        public string? ColorId { get; set; }
    }
}
