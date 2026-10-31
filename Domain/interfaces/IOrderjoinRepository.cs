using Domain.Models;

namespace Domain.interfaces;

public interface IOrderjoinRepository
{
    Task<List<OrderJoin>> OrdersJoinbyCustomer();
}
