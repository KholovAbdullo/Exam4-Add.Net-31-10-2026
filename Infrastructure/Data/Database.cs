using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public static class Database
{
    private static string connectionString = "Host=localhost;Port=5432;Database=Exam4;Username=postgres;Password=1234";
    public static IDbConnection Connection() => new NpgsqlConnection(connectionString);
}
