using Microsoft.EntityFrameworkCore.Design;

namespace SqlDbIntro.DataAccess
{
    public class ContextProvider : IDesignTimeDbContextFactory<SqlDbContext>
    {
        public SqlDbContext CreateDbContext(string[] args)
        {
            var options = ContextOptionsProvider.GetDbContextOptions();
            return new SqlDbContext(options);
        }
    }
}
