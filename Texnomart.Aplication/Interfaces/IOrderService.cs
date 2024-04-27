using Texnomart.Aplication.DTOs.OrderDTOs;

namespace Texnomart.Aplication.Interfaces;

public interface IOrderService
{
    Task CreateAsync(AddOrderDto dto);
    Task DeleteAsync(int id);
    Task<IEnumerable<OrderDto>> GetAllAsync();
    Task<OrderDto?> GetByIdAsync(int id);
}
