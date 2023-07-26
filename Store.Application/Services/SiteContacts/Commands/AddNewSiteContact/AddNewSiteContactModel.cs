using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.SiteContacts.Commands.AddNewSiteContact
{
    public class AddNewSiteContactModel
    {
        public string? Id { get; set; }
        public string ContactType { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Value { get; set; }
        public string? CssClass { get; set; }
        public bool IsActive { get; set; }
    }
}
