using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class ProductCatalog : IProductCatalog
    {
        public List<Product> ProductList { get; }
        private readonly JsonDeserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("productsDatabase");

        public ProductCatalog()
        {
            ProductList = deserializer.GetProductList(filepath);
        }
    }
}