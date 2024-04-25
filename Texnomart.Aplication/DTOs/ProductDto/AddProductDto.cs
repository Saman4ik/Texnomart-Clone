using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.DTOs.ProductDto;

public class AddProductDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int CategoryId { get; set; }

    public static implicit operator Product(AddProductDto dto)
    {
        return new Product  ()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };
    }
}