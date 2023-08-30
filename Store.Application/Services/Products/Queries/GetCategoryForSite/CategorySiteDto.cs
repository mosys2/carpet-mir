namespace Store.Application.Services.ProductsSite.Queries.GetCategoryForSite
{
    public class CategorySiteDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public List<SubCategorySitDto> Child { get; set; }
    }
}
