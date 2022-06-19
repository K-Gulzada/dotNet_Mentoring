using EntityFrameworkIntro.Context;
using EntityFrameworkIntro.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EntityFrameworkIntro.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        #region Private members

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructor

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region IDbContextFactory Implementation

        ShopDbContext IDbContextFactory.Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
            string connectionString = _configuration.GetSection("DbConnectionString").Value;

            optionsBuilder.UseSqlite(_configuration.GetSection("DbConnectionString").Value, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            return new ShopDbContext(optionsBuilder.Options);
        }

        #endregion
    }
}
