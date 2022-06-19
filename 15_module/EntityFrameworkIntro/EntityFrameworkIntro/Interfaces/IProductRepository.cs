using EntityFrameworkIntro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkIntro.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProduct(int id);
        IEnumerable<Product> GetAll();
        void DeleteProduct(Product product);
        void DeleteProduct(int id);
    }
}
