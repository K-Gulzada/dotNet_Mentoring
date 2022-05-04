using SqlDbIntro.DataLayer.DataAccess;
using SqlDbIntro.DataLayer.Entities;
using SqlDbIntro.DataLayer.Repositories.Interfaces;

namespace SqlDbIntro.DataLayer.Repositories.Implementations
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
        }
    }
}
