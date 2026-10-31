using Dapper;
using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class OrderjoinRepository : IOrderjoinRepository
{
    public async Task<List<OrderJoin>> OrdersJoinbyCustomer()
    {
        using var conn=Database.Connection();
        conn.Open();
        var query="select o.id,c.fullname,o.amount,o.created_at from orders o join customers c on o.customer_id=c.id";
        var resilt = await conn.QueryAsync<OrderJoin>(query);
        return resilt.ToList();
    }
}
