using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.DTOs.OrderDTOs;

public class OrderDto : AddOrderDto
{
    public int Id { get; set; }

    public static implicit operator OrderDto(Order order)
    {
        return new OrderDto {
            Id = order.Id,
            Date = order.Date,
            TotalPrice = order.TotalPrice,
            UserId = order.UserId,
            ProductId = order.ProductId
        };
    }
}
