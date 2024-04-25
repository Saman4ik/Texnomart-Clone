using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.DTOs.ProductDto;

public class ProductDto : AddProductDto
{
    public int Id { get; set; }

    public static implicit operator ProductDto(Product product)
    {
        return new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            CategoryId = product.CategoryId
        };
    }
}
