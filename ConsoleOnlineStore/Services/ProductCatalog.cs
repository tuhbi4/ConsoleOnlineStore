using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class ProductCatalog : IProductCatalog
    {
        public List<Product> ProductList { get; }

        public ProductCatalog(IRepository<Product> productsRepository)
        {
            ProductList = productsRepository.GetItemList();
        }
    }
}