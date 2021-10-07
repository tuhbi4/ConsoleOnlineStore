using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;

namespace ConsoleOnlineStore.Models
{
    public class Catalog : ICatalog
    {
        public List<Product> ProductList { get; }
        private readonly JsonDeserializer deserializer = new();

        public Catalog()
        {
            ProductList = deserializer.GetData(@"database.json");
        }
    }
}