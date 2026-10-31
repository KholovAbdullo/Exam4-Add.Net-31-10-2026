using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class OrderRepository : IOrderRepository
{
    public async Task<bool> AddOrder(Orders order)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="insert into orders(customer_id,amount,created_at) values(@customer_id,@amount,@created_at)";
        var resilt = await conn.ExecuteAsync(query,order);
        return resilt>0;
    }

    public async Task<bool> DeleteOrder(int OrderId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="delete from orders where id=@OrderId";
        var resilt = await conn.ExecuteAsync(query,new{OrderId});
        return resilt>0;
    }

    public async Task<Orders> GetCourse(int OrderId)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query = "select * from orders where id=@OrderId";
        var resilt = await conn.QuerySingleOrDefaultAsync<Orders>(query,new{OrderId});
        return resilt!;
    }

    public async Task<List<Orders>> GetOrder()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query= await conn.QueryAsync<Orders>("select * from orders");
        return query.ToList();
    }

    public async Task<bool> UpdateOrder(Orders Order)
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="update orders customer_id=@customer_id,amount=@amount,created_at=@created_at where id=@id";
        var resilt = await conn.ExecuteAsync(query,Order);
        return resilt>0;
    }

}
