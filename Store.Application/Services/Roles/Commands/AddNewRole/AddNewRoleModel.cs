using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Roles.Commands.AddNewRole
{
    public class AddNewRoleModel
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? PersianTitle { get; set; }
        public string? NormalizedName { get; set; }
        public string? Description { get; set; }
    }
}
