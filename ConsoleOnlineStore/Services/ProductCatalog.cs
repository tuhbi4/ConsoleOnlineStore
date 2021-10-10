using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Repository;

namespace ConsoleOnlineStore.Services
{
    public class ProductCatalog : IProductCatalog
    {
        public List<Product> ProductList { get; }
        private readonly Repository<Product> productsRepository = new(ConfigurationManager.AppSettings.Get("productsJson"));

        public ProductCatalog()
        {
            ProductList = productsRepository.GetItemList();
        }
    }
}