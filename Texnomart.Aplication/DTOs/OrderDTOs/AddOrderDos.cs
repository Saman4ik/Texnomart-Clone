using Texnomart.Domain.Entities;

namespace Texnomart.Aplication.DTOs.OrderDTOs;

public class AddOrderDos
{
    public DateTime Date { get; set; }
    public double TotalPrice { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }

    public static implicit  operator Order(AddOrderDos dto)
    {
        return new Order
        {
            Date = dto.Date,
            TotalPrice = dto.TotalPrice,
            UserId = dto.UserId,
            ProductId = dto.ProductId
        };
    }
}
