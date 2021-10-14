using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Services
{
    public class ProductCatalog : IProductCatalog
    {
        public List<Product> CatalogList { get; }

        public ProductCatalog(IRepository<Product> productRepository)
        {
            CatalogList = productRepository.Read();
        }
    }
}