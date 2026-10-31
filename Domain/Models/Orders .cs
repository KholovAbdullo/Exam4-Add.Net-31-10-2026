namespace Domain.Models;

public class Orders
{
    public int Id { get; set; }
    public int customersId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Created_at { get; set; }=DateTime.Now;
}
