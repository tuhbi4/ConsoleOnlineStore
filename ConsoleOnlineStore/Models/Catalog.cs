using ConsoleOnlineStore.Interfaces;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleOnlineStore.Models
{
    public class Catalog : ICatalog
    {
        public List<Product> ProductList { get; }
        private readonly Deserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("productsDatabase");

        public Catalog()
        {
            ProductList = deserializer.GetProductListFromJson(filepath);
        }
    }
}