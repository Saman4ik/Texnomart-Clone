using Texnomart.Aplication.DTOs.ProductDto;

namespace Texnomart.Aplication.Interfaces;

public interface IProductService
{
    Task CreateAsync(AddProductDto dto);
    Task UpdateAsync(ProductDto dto);
    Task DeleteAsync(int id);
    Task<ProductDto?> GetByIdAsync(int id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetByNameAsync(string name);
}
