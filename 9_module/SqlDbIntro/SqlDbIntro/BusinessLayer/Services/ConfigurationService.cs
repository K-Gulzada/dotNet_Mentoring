using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlDbIntro.BusinessLayer.ViewModels;
using SqlDbIntro.DataLayer.DataAccess;
using SqlDbIntro.DataLayer.Entities;
using SqlDbIntro.DataLayer.Repositories.Implementations;
using SqlDbIntro.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlDbIntro.BusinessLayer.Services
{
    public class ConfigurationService
    {
        public IServiceProvider Register()
        {
            var services = new ServiceCollection();

            services.AddLogging();
            services.AddScoped<IEmployeeService, EmployeeServiceImpl>();

            var configurationBuilder = new ConfigurationBuilder();
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = projectPath + @"appsettings.json";
            configurationBuilder.AddJsonFile(filePath, false);
            string connectionString = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnectionString").Value;
            services.AddDbContext<SqlDbContext>(option => option.UseSqlServer(connectionString));

            RegisterRepositories(services);
            RegisterAutoMapper(services);

            return services.BuildServiceProvider();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            IEnumerable<Type> implementationsType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type =>
                        !type.IsInterface && type.GetInterface(typeof(IBaseRepository<>).Name) != null);

            foreach (Type implementationType in implementationsType)
            {
                IEnumerable<Type> servicesType = implementationType
                    .GetInterfaces()
                    .Where(r => !r.Name.Contains(typeof(IBaseRepository<>).Name));

                foreach (Type serviceType in servicesType)
                {
                    services.AddScoped(serviceType, implementationType);
                }
            }
        }

        private void RegisterAutoMapper(IServiceCollection services)
        {
            var configurationExp = new MapperConfigurationExpression();

            MapBothSide<Person, PersonVM>(configurationExp);
            MapBothSide<Employee, EmployeeVM>(configurationExp);
            MapBothSide<Address, AddressVM>(configurationExp);
            MapBothSide<Company, CompanyVM>(configurationExp);

            var config = new MapperConfiguration(configurationExp);
            var mapper = new Mapper(config);
            services.AddScoped<IMapper>(x => mapper);
        }

        public void MapBothSide<Type1, Type2>(MapperConfigurationExpression configurationExp)
        {
            configurationExp.CreateMap<Type1, Type2>();
            configurationExp.CreateMap<Type2, Type1>();
        }
    }
}
