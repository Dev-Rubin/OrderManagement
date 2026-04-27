using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using OrderManagement.Infrastructure.Persistence.Interface;
using System.Data;

namespace OrderManagement.Infrastructure.Persistence.Service
{
    public class AppReadDbConnection : IAppReadDbConnection, IDisposable
    {
        private readonly IDbConnection connection;
        public AppReadDbConnection(IDbConnection conn)
        {
            connection = conn;
        }
        public AppReadDbConnection(IConfiguration configuration)
        {
            connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
