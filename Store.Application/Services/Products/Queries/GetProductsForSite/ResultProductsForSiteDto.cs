namespace Store.Application.Services.ProductsSite.Queries.GetProductsForSite
{
	public class ResultProductsForSiteDto
    {
       public List<ProductsForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
        public string? Paginate { get; set; }
        public List<SubCategoryDto>? SuCategories { get; set; }
    }
}
