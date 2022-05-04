using Microsoft.EntityFrameworkCore;
using SqlDbIntro.DataLayer.DataAccess;
using SqlDbIntro.DataLayer.Entities;
using SqlDbIntro.DataLayer.Repositories.Interfaces;

namespace SqlDbIntro.DataLayer.Repositories.Implementations
{
    public abstract class BaseRepository<DbModel> : IBaseRepository<DbModel> where DbModel : BaseModel
    {
        protected SqlDbContext _sqlDbContext;
        protected DbSet<DbModel> _dbSet;

        public BaseRepository(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
            _dbSet = _sqlDbContext.Set<DbModel>();
        }
        public DbModel Get(long id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public List<DbModel> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(DbModel model)
        {
            _dbSet.Remove(model);
            _sqlDbContext.SaveChanges();
        }

        public DbModel Save(DbModel model)
        {
            if (model.Id > 0)
            {
                _sqlDbContext.Entry(model).State = EntityState.Modified;
            }
            else
            {
                _dbSet.Add(model);
            }

            _sqlDbContext.SaveChanges();

            return model;
        }
    }
}
