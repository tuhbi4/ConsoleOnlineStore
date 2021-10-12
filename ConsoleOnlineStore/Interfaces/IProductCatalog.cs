using System.Collections.Generic;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IProductCatalog
    {
        public List<CatalogItem> CatalogList { get; }
    }
}