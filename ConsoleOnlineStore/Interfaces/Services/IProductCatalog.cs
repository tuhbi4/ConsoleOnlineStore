using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IProductCatalog
    {
        public List<Product> CatalogList { get; }
    }
}