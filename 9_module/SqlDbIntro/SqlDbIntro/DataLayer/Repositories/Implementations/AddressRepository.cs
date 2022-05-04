using SqlDbIntro.DataLayer.DataAccess;
using SqlDbIntro.DataLayer.Entities;
using SqlDbIntro.DataLayer.Repositories.Interfaces;

namespace SqlDbIntro.DataLayer.Repositories.Implementations
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(SqlDbContext sqlDbContext) : base(sqlDbContext)
        {
        }
    }
}
