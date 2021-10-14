using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

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