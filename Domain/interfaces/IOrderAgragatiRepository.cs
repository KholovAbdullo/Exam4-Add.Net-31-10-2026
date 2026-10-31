using Domain.Models;

namespace Domain.interfaces;

public interface IOrderAgragatiRepository
{
    Task<decimal> GetAmount();
    Task<List<OrderAgragati>> Getcustomercountorder();
    Task<List<OrderAgragati>> Getcustomer();
}
