using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        private protected NorthwindDbContext _dbContext;
        public CategoryRepository(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CategoryEntity> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public CategoryEntity Get(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(x => x.CategoryID == id);

            if (category == null)
            {
                throw new NullReferenceException();
            }

            return category;
        }

        public CategoryEntity Get(string name)
        {
            var category = _dbContext.Categories.SingleOrDefault(x => x.CategoryName == name);

            if (category == null)
            {
                throw new NullReferenceException();
            }

            return category;
        }

        public void Create(CategoryEntity item)
        {

            _dbContext.Categories.Add(item);
            // _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var category = _dbContext.Categories.SingleOrDefault(x => x.CategoryID == id);

            if (category == null)
            {
                return false;
            }

            _dbContext.Categories.Remove(category);
            //  _dbContext.SaveChanges();

            return true;
        }

        public void Update(CategoryEntity category)
        {
            if (category.CategoryID > 0)
            {
                _dbContext.Entry(category).State = EntityState.Modified;
                // _dbContext.Update(category);
                //_dbContext.SaveChanges();
            }
        }
    }
}
