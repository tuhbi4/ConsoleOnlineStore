using ConsoleOnlineStore.Interfaces;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Models
{
    public class Catalog : ICatalog
    {
        public List<Product> ProductList { get; }
        private readonly Deserializer deserializer = new();
        public Catalog()
        {
            ProductList = deserializer.GetDataFromJson(@"database.json");
        }
    }
}
