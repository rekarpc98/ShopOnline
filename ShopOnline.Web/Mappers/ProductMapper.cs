using Riok.Mapperly.Abstractions;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Models.Entities.Products;

namespace ShopOnline.Web.Mappers;

[Mapper]
public static partial class ProductMapper
{
	public static partial Product FromDto(this ProductDto productDto);
	public static partial IEnumerable<Product> FromDtos(this IEnumerable<ProductDto> productDtos);
}