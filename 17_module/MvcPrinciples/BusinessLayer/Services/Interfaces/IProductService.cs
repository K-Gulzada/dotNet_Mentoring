using BusinessLayer.DTO;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProductList();
        Product GetById(int id);
        Product GetByName(string name);
        void Create(Product product);
        void Update(Product product);
        bool Delete(int id);
    }
}
