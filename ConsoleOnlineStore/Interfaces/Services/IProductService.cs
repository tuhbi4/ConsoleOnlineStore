using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IProductService
    {
        public List<Product> GetCatalog();
    }
}