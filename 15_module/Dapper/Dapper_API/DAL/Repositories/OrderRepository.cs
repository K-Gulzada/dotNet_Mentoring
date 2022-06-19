using Dapper;
using Models;
using Models.enums;
using System.Data;

namespace Dapper_API.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _context;
        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task Create(Order order)
        {
            string sqlQuery = "INSERT into Orders (Status,[CreatedDate], [UpdatedDate], ProductId)" +
                                          " values (@Status, @CreatedDate, @UpdatedDate, @ProductId)";
            var parameters = new DynamicParameters();
            parameters.Add("Status", order.Status, DbType.String);
            parameters.Add("CreatedDate", order.CreatedDate, DbType.DateTime);
            parameters.Add("UpdatedDate", order.UpdatedDate, DbType.DateTime);
            parameters.Add("ProductId", order.ProductId, DbType.Int32);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(sqlQuery, parameters);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Orders WHERE Id = @Id";

            using var connection = _context.CreateConnection();         
            await connection.ExecuteAsync(query, new { Id = id });         
        }

        public async Task<OrderEntity> GetById(int id)
        {
            string sqlQuery = $"SELECT * FROM orders WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            var order = await connection.QueryAsync<OrderEntity>(sqlQuery, new { Id = id });
            return order.FirstOrDefault();
        }

        public async Task<IEnumerable<OrderEntity>> GetOrders()
        {
            string sqlQuery = "SELECT * FROM Orders";

            using var connection = _context.CreateConnection();
            var orders = await connection.QueryAsync<OrderEntity>(sqlQuery);
            return orders.ToList();
        }

        public async Task Update(Order order, int id)
        {
            string sqlQuery = "UPDATE Orders SET Status = @Status, CreatedDate = @CreatedDate," +
                                              " UpdatedDate = @UpdatedDate, ProductId = @ProductId WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("Status", order.Status, DbType.String);
            parameters.Add("CreatedDate", order.CreatedDate, DbType.DateTime);
            parameters.Add("UpdatedDate", order.UpdatedDate, DbType.DateTime);
            parameters.Add("ProductId", order.ProductId, DbType.Int32);
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(sqlQuery, parameters);
        }

        public async Task<List<OrderEntity>> GetOrderByCreatedDateMonth(string month)
        {
            using var connection = _context.CreateConnection();
            
            connection.Open();
            string procedure = "SP_GetOrderByCreatedDateMonth";
            var parameters = new DynamicParameters();
            parameters.Add("Month", month, DbType.String);

            var orders = connection.Query<OrderEntity>(procedure, parameters,
            commandType: CommandType.StoredProcedure).ToList();  

            return orders;
        }
        public async Task<List<OrderEntity>> GetByStatus(Status status)
        {
            using var connection = _context.CreateConnection();

            connection.Open();
            string procedure = "SP_GetOrderByStatus";
            var parameters = new DynamicParameters();
            parameters.Add("Status", status, DbType.Int32);

            var orders = connection.Query<OrderEntity>(procedure, parameters,
            commandType: CommandType.StoredProcedure).ToList();

            return orders;
        }

        public async Task BulkDeleteOrderById(List<int> ids)
        {
            using var connection = _context.CreateConnection();

            connection.Open();
            string procedure = "SP_DeleteOrdersById";
            foreach(var id in ids)
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                connection.Query<OrderEntity>(procedure, parameters,
                commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
