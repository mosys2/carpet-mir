using Store.Common.Constant.GroupTypes;
using Store.Domain.Entities.Commons;
using Store.Domain.Entities.Pages;
using Store.Domain.Entities.Products;
using Store.Domain.Entities.Translate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities.Groups
{
    public class GroupItem:BaseEntity
    {
        public virtual Group Group { get; set; }
        public string? GroupId { get; set; }
        public string Title { get; set; }
        public GroupType  GroupType { get; set; }
        public virtual Language Language { get; set; }
        public string LanguageId { get; set; }
        public ICollection<PageCreator> PageCreators { get; set; }
    }
}
