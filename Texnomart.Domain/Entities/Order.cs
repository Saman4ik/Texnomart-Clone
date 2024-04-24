namespace Texnomart.Domain.Entities;

public class Order : BaseEntity
{
    public DateTime Date { get; set; }
    public double TotalPrice { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

}
