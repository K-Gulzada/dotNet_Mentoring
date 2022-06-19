using Models;

namespace Dapper_API.DAL.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();
        Task<ProductEntity> GetById(int id);
        Task Create(Product product);
        Task Update(Product product, int id);
        Task Delete(int id);
    }
}
