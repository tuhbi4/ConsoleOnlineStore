using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class ProductCatalog : IProductCatalog
    {
        public List<CatalogItem> CatalogList { get; }
        private readonly List<Product> productList;

        public ProductCatalog(IRepository<Product> productRepository)
        {
            productList = productRepository.Read();
            MakeCatalog();
        }

        private void MakeCatalog()
        {
            foreach (Product product in productList)
            {
                foreach (CatalogItem catalogItem in CatalogList)
                {
                    if (CatalogList.Count != 0 && catalogItem.Id == product.Id)
                    {
                        catalogItem.Increment();
                    }
                    else
                    {
                        CatalogList.Add(new(product));
                    }
                }
            }
        }
    }
}