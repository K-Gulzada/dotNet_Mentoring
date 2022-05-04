using SqlDbIntro.DataLayer.DataAccess;
using SqlDbIntro.DataLayer.Entities;
using SqlDbIntro.DataLayer.Repositories.Interfaces;

namespace SqlDbIntro.DataLayer.Repositories.Implementations
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
        }
    }
}
