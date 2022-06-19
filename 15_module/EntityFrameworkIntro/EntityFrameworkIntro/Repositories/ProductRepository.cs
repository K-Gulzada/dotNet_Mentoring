using EntityFrameworkIntro.Entities;
using EntityFrameworkIntro.Interfaces;

namespace EntityFrameworkIntro.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContextFactory _factory;

        public ProductRepository(IDbContextFactory factory)
        {
            _factory = factory;
        }

        public void AddProduct(Product product)
        {
            using (var context = _factory.Create())
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Weight = product.Weight,
                    Height = product.Height,
                    Width = product.Width,
                    Length = product.Length
                };

                context.Products.Add(newProduct);
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = _factory.Create())
            {
                var productToDelete = context.Products.SingleOrDefault(s => s.Id == product.Id);

                context.Products.Remove(productToDelete);

                context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            using (var context = _factory.Create())
            {
                var product = context.Products.SingleOrDefault(s => s.Id == id);

                context.Products.Remove(product);

                context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (var context = _factory.Create())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int id)
        {
            using (var context = _factory.Create())
            {
                return context.Products.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
