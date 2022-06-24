using AutoMapper;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer
{
    static class IocConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            var configurationExp = new MapperConfigurationExpression();
            var config = new MapperConfiguration(configurationExp);
            var mapper = new Mapper(config);
            services.AddScoped<IMapper>(x => mapper);

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IRepository<CategoryEntity>, CategoryRepository>();
            services.AddScoped<IRepository<ProductEntity>, ProductRepository>();

            string connectionString = "Server=DESKTOP-UQEHSLO\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;"; // json
                                                                                                                        // services.AddDbContext<NorthwindDbContext>(option => option.UseSqlServer(connectionString));
            services.AddDbContext<NorthwindDbContext>(options => { options.UseSqlServer(connectionString); }, ServiceLifetime.Transient);
        }
    }
}
