using AdoNetFundamentals.Entities;
using AdoNetFundamentals.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace AdoNetFundamentalsTest
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private Mock<IProductRepository> _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Test]
        public void GetAllProductsReturnProductList()
        {
            List<Product> products = new List<Product> { new Product("Test Name", "Test Description", 34, 234, 654, 123) };
            var result = _productRepository.Setup(x => x.GetAllProducts()).Returns(products);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetProductByNameReturnsProduct()
        {
            string productName = "Test Name";
            Product product = new Product(productName, "Test Description", 34, 234, 654, 123);
            var result = _productRepository.Setup(x => x.GetProductByName(productName)).Returns(product);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteProductByIdTest()
        {
            List<Product> products = new List<Product> { new Product("Test Name", "Test Description", 34, 234, 654, 123) };

            int idToDelete = 1;
            _productRepository
                .Setup(m => m.DeleteProductById(idToDelete))
                .Callback<Product>((entity) => products.Remove(entity));
            Assert.AreEqual(0, products.Count());
            _productRepository.Verify(s => s.DeleteProductById(It.IsAny<Product>().Id), Times.Once);
        }
    }
}