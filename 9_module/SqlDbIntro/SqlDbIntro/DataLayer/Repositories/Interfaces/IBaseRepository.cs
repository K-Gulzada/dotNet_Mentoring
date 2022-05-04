using SqlDbIntro.DataLayer.Entities;

namespace SqlDbIntro.DataLayer.Repositories.Interfaces
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        DbModel Get(long id);
        List<DbModel> GetAll();
        void Remove(DbModel model);
        DbModel Save(DbModel model);
    }
}