using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private NorthwindDbContext _dbContext;
        private CategoryRepository categoryRepository;
        private ProductRepository productRepository;

        public EFUnitOfWork(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<CategoryEntity> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_dbContext);
                return categoryRepository;
            }
        }

        public IRepository<ProductEntity> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(_dbContext);
                return productRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
