using AutoMapper;
using BusinessLayer.DTO;
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
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            var configurationExp = new MapperConfigurationExpression();
            configurationExp.CreateMap<Product, ProductEntity>();
            configurationExp.CreateMap<ProductEntity, Product>();

            configurationExp.CreateMap<Category, CategoryEntity>();
            configurationExp.CreateMap<CategoryEntity, Category>();

            configurationExp.CreateMap<Supplier, SupplierEntity>();
            configurationExp.CreateMap<SupplierEntity, Supplier>();
            var config = new MapperConfiguration(configurationExp);
            var mapper = new Mapper(config);

            services.AddScoped<IMapper>(x => mapper);

            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IRepository<CategoryEntity>, CategoryRepository>();
            services.AddScoped<IRepository<ProductEntity>, ProductRepository>();

            string connectionString = configuration.GetSection("DefaultConnection").Value;
     
            services.AddDbContext<NorthwindDbContext>(options => { options.UseLazyLoadingProxies().UseSqlServer(connectionString); }, ServiceLifetime.Transient);            
        }
    }
}
