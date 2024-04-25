using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.DTOs.CategoryDTOs;

public class AddCategoryDto
{
    public string Name { get; set; } = "";

    public static implicit operator Category(AddCategoryDto dto)
    {
        return new Category
        {
            Name = dto.Name
        };
    }
}
