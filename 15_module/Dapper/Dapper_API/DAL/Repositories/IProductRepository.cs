using Models;

namespace Dapper_API.DAL.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int id);
        Task Create(ProductDTO product);
        Task Update(ProductDTO product, int id);
        Task Delete(int id);
    }
}
