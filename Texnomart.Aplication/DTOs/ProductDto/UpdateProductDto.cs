using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.DTOs.ProductDto;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public int CategoryId { get; set; }

    public static implicit operator Product(UpdateProductDto dto)
    {
        return new Product()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };
    }
}
