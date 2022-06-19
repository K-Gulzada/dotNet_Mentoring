using EntityFrameworkIntro.Entities;
using EntityFrameworkIntro.Factories;
using EntityFrameworkIntro.Interfaces;
using EntityFrameworkIntro.Repositories;
using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

IDbContextFactory dbContext = new DbContextFactory(configuration);

IOrderRepository orderRepository = new OrderRepository(dbContext);
IProductRepository productRepository = new ProductRepository(dbContext);

var product = new Product("Test Product Name", "Test Product Description", 2.3f, 4.5f, 6.7f, 8.9f);
productRepository.AddProduct(product);


var products = productRepository.GetAll();
foreach (var prod in products)
{
    prod.ToString();
}