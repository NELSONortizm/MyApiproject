using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApiProject.Data;
using MyApiProject.Entities;
using MyApiProject.Repositories;

namespace MyApiProjectTests
{
    internal class ProductRepositoryTests
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _repository;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new AppDbContext(options);
            _repository = new ProductRepository(_context);
        }

        [Fact]
        public async Task CanAddProduct()
        {
            var product = new Product { Name = "Test Product", Price = 10.99m };

            await _repository.AddAsync(product);

            var result = await _repository.GetByIdAsync(product.Id);
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.Name);
        }

        [Fact]
        public async Task CanGetAllProducts()
        {
            var product1 = new Product { Name = "Product1", Price = 10.99m };
            var product2 = new Product { Name = "Product2", Price = 20.99m };

            await _repository.AddAsync(product1);
            await _repository.AddAsync(product2);

            var result = await _repository.GetAllAsync();
            Assert.Equal(2, result.Count());
        }

    }//
}
