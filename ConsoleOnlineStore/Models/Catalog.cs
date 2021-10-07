using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;

namespace ConsoleOnlineStore.Models
{
    public class Catalog : ICatalog
    {
        public List<Product> ProductList { get; }
        private readonly JsonDeserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("productsDatabase");

        public Catalog()
        {
            ProductList = deserializer.GetProductList(filepath);
        }
    }
}