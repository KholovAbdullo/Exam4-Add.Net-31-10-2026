using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CustomerRepository : ICustomerRepository
{
    public async Task<bool> AddCustomer(Customers courses)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "insert into customers(fullname) values(@fullname)";
        var resilt = await conn.ExecuteAsync(query,courses);
        return resilt>0;
    }

    public async Task<bool> DeleteCustomer(int customerId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query = "delete from customers where id=@customerId";
        var resilt = await conn.ExecuteAsync(query,new{customerId});
        return resilt>0;
    }

    public async Task<Customers> GetCourse(int customerId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select * from customers where id=@customerId";
        var resilt = await conn.QuerySingleOrDefaultAsync<Customers>(query,new{customerId});
        return resilt!;
    }

    public async Task<List<Customers>> GetCustomer()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query= await conn.QueryAsync<Customers>("select * from customers");
        return query.ToList();
    }

    public async Task<bool> UpdateCustomer(Customers Customer)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query="update customers set fullname=@fullname where id=@id";
        var resilt = await conn.ExecuteAsync(query,Customer);
        return resilt>0;
    }

}
