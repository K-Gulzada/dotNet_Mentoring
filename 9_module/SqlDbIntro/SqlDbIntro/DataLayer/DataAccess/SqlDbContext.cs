using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlDbIntro.DataLayer.Entities;
using System.Reflection;

namespace SqlDbIntro.DataLayer.DataAccess
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public SqlDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = projectPath + @"appsettings.json";
            configurationBuilder.AddJsonFile(filePath, false);
            string connectionString = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnectionString").Value;
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
