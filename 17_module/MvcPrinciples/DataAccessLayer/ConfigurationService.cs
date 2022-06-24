using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class ConfigurationService
    {
        public static void ConfigureMsSqlContext(this IServiceCollection services) // builder.Services
        {
            //IConfiguration configuration = new ConfigurationBuilder().Build();

            string connectionString = "Server=DESKTOP-UQEHSLO\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";
            services.AddDbContext<NorthwindDbContext>(option => option.UseSqlServer(connectionString));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();            
            services.AddScoped<IRepository<CategoryEntity>, CategoryRepository>();            
            services.AddScoped<IRepository<ProductEntity>, ProductRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}

/*
 
 'AddDbContext' was called with configuration, but the context type 'NorthwindDbContext' only declares a parameterless constructor. 
 This means that the configuration passed to 'AddDbContext' will never be used. If configuration is passed to 'AddDbContext', 
 then 'NorthwindDbContext' should declare a constructor that accepts a DbContextOptions<NorthwindDbContext> and must pass 
 it to the base constructor for DbContext.'
 
 */
