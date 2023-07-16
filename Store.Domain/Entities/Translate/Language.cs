using Store.Domain.Entities.Commons;
using Store.Domain.Entities.HomePages;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Translate
{
    public class Language:BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Slider> Sliders { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
