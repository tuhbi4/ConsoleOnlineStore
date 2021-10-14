using System.Collections.Generic;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IProductCatalog
    {
        public List<Product> CatalogList { get; }
    }
}