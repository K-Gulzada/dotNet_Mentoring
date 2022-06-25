using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using ReflectionIT.Mvc.Paging;

namespace BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private protected IUnitOfWork _database;
        private protected IMapper _mapper;
        public ProductService(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public List<Product> GetProductList()
        {
            var productEntities = _database.Products.GetAll();
            var products = productEntities.Select(x => _mapper.Map<Product>(x)).ToList();

            return products;
        }

        public PagingList<Product> GetAll(int pageSize, int page)
        {
            var productEntities = _database.Products.GetAll();
            var products = productEntities.Select(c => _mapper.Map<Product>(c)).ToList();
            var model = PagingList.Create(products, pageSize, page);
            model.Action = "ProductList";

            return model;
        }

        public Product GetById(int id)
        {
            var productEntity = _database.Products.Get(id);

            return _mapper.Map<Product>(productEntity);
        }

        public Product GetByName(string name)
        {
            var productEntity = _database.Products.Get(name);

            return _mapper.Map<Product>(productEntity);
        }

        public void Create(Product product)
        {
            var productEntity = _mapper.Map<ProductEntity>(product);
            _database.Products.Create(productEntity);
            _database.Save();
        }

        public bool Delete(int id)
        {
            var isSuccess = _database.Products.Delete(id);
            _database.Save();

            return isSuccess;
        }

        public void Update(Product product)
        {
            _database.Products.Update(_mapper.Map<ProductEntity>(product));
            _database.Save();
        }
    }
}
