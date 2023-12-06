namespace ShopOnline.Api.Models.Entities;

public class ProductCategory
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public Guid? ParentCategoryId { get; set; }
	public ProductCategory? ParentCategory { get; set; }
	public List<ProductCategory> Children { get; set; } = new();
}