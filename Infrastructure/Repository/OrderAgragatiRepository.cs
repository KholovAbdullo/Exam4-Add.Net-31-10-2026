using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class OrderAgragatiRepository : IOrderAgragatiRepository
{
    public async Task<decimal> GetAmount()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select sum(amount) from orders";
        var resilt = await conn.QuerySingleAsync<decimal>(query);
        return resilt;
    }

    public async Task<List<OrderAgragati>> Getcustomer()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select c.id,c.fullname,sum(o.amount) from customers c join orders o on c.id=o.customer_id group by c.id,c.fullname order by sum(o.amount) desc limit 3";
        var resilt = await conn.QueryAsync<OrderAgragati>(query);
        return resilt.ToList();
    }
    
    public async Task<List<OrderAgragati>> Getcustomercountorder()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select c.id,c.fullname,count(o.id) from customers c join orders o on c.id=o.customer_id group by c.id,c.fullname order by count(o.id) desc";
        var resilt = await conn.QueryAsync<OrderAgragati>(query);
        return resilt.ToList();
    }

}
