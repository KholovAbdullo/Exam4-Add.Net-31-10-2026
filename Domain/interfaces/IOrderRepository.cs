using Domain.Models;

namespace Domain.interfaces;

public interface IOrderRepository
{
    Task<bool> AddOrder(Orders order);
    Task<bool> UpdateOrder(Orders Order);
    Task<bool> DeleteOrder(int OrderId);
    Task<Orders> GetCourse(int OrderId);
    Task<List<Orders>> GetOrder();
}
