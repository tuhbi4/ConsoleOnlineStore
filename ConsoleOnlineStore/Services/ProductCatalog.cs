using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class ProductCatalog : IProductCatalog
    {
        public List<Product> ProductList { get; }
        private readonly JsonDeserializer deserializer = new();

        public ProductCatalog()
        {
            ProductList = deserializer.GetData(@"database.json");
        }
    }
}