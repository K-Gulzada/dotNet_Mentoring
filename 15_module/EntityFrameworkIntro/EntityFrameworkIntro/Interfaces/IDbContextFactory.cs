using EntityFrameworkIntro.Context;

namespace EntityFrameworkIntro.Interfaces
{
    public interface IDbContextFactory
    {
        ShopDbContext Create();
    }
}
