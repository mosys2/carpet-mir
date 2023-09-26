using Store.Application.Services.Materials.Commands.AddNewMaterial;
using Store.Application.Services.Materials.Queries.GetAllMaterial;
using Store.Application.Services.Profile.Commands.ChangePassword;
using Store.Application.Services.Profile.Queries;

namespace EndPointStore.Areas.Admin.Models.ViewModelProfile
{
    public class ViewModelProfile
    {
        public GetProfileUserDto GetProfileUserDto { get; set; }
        public ChangePassModel ChangePassModel { get; set; }
    }
}
