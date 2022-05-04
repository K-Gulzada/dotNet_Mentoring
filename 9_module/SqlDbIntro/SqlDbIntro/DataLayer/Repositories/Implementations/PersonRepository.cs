using SqlDbIntro.DataLayer.DataAccess;
using SqlDbIntro.DataLayer.Entities;
using SqlDbIntro.DataLayer.Repositories.Interfaces;

namespace SqlDbIntro.DataLayer.Repositories.Implementations
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
        }
    }
}
