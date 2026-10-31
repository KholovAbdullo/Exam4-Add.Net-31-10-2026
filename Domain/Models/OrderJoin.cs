namespace Domain.Models;

public class OrderJoin
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }=null!;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}
