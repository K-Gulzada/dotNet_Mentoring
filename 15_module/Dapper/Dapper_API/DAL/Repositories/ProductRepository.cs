using Dapper;
using Models;
using System.Data;

namespace Dapper_API.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task Create(ProductDTO product)
        {
            string sqlQuery = "INSERT INTO Products (Name, Description, Weight, Height, Width, Length) " +
                                            "VALUES(@Name, @Description, @Weight, @Height, @Width, @Length)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("Weight", product.Weight, DbType.Double);
            parameters.Add("Height", product.Height, DbType.Double);
            parameters.Add("Width", product.Width, DbType.Double);
            parameters.Add("Length", product.Length, DbType.Double);

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(sqlQuery, parameters);
        }

        public async Task Delete(int id)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";

            using var connection = _context.CreateConnection();            
            await connection.ExecuteAsync(query, new { Id = id });           
        }

        public async Task<Product> GetById(int id)
        {
            string sqlQuery = $"SELECT * FROM Products WHERE Id = @Id";

            using var connection = _context.CreateConnection();
            var order = await connection.QueryAsync<Product>(sqlQuery, new { Id = id });
            return order.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            string sqlQuery = "SELECT * FROM Products";

            using var connection = _context.CreateConnection();
            var products = await connection.QueryAsync<Product>(sqlQuery);
            return products.ToList();
        }

        public async Task Update(ProductDTO product, int id)
        {
            string sqlQuery = "UPDATE Products SET Name = @Name, Description = @Description," +
                             " Weight = @Weight, Height = @Height, Width = @Width, Length = @Length WHERE Id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("Weight", product.Weight, DbType.Double);
            parameters.Add("Height", product.Height, DbType.Double);
            parameters.Add("Width", product.Width, DbType.Double);
            parameters.Add("Length", product.Length, DbType.Double);
            parameters.Add("Id", id, DbType.Int32);

            using var connection = _context.CreateConnection();            
            await connection.ExecuteAsync(sqlQuery, parameters);           
        }
    }
}
