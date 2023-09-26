using Store.Application.Services.Authors.Commands.AddNewAuthor;
using Store.Application.Services.Roles.Commands.AddNewRole;
using Store.Application.Services.Roles.Queries.GetAllRole;

namespace EndPointStore.Areas.Admin.Models.ViewModelRole
{
    public class ViewModelRole
    {
        public AddNewRoleModel AddNewRole { get; set; }
        public List<GetAllRoleDto> GetAllRoles { get; set; }
    }
}
