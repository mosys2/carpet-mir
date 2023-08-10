using Store.Application.Services.Products.Commands.AddNewFeatureToCategory;
using Store.Application.Services.Products.Queries.GetAllCategoryFeature;

namespace EndPointStore.Areas.Admin.Models.ViewModelCategoryFeature
{
    public class ViewModelCategoryFeature
    {
        public AddNewFeatureToCategoryModel AddNewFeatureToCategoryModel { get; set; }
        public List<GetAllCategoryFeatureDto> GetAllCategoryFeatures { get; set; }
    }
}
