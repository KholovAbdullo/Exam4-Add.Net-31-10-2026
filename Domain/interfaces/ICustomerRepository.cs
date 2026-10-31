using Domain.Models;

namespace Domain.interfaces;

public interface ICustomerRepository
{
    Task<bool> AddCustomer(Customers courses);
    Task<bool> UpdateCustomer(Customers Customer);
    Task<bool> DeleteCustomer(int customerId);
    Task<Customers> GetCourse(int customerId);
    Task<List<Customers>> GetCustomer();
}
