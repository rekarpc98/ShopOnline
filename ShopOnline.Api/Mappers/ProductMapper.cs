using Riok.Mapperly.Abstractions;
using ShopOnline.Api.Models.Entities.Products;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Mappers;

[Mapper]
public static partial class ProductMapper
{
	public static partial ProductDto ToProductDto(this Product product);
	public static partial IEnumerable<ProductDto> ToProductsDto(this IEnumerable<Product> products);
}