using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetCatalog()
        {
            return productRepository.Read();
        }
    }
}