using AdoNetFundamentals.Entities;

namespace AdoNetFundamentals.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        void AddProduct(string name, string description, float weight, float height, float width, float length);
        void UpdateProduct(string columnName, string value, int id);
        void DeleteProductById(int id);
        Product GetProductByName(string productName);
    }
}
