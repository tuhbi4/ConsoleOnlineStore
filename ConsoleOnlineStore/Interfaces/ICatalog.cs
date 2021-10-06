using ConsoleOnlineStore.Models;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ICatalog
    {
        public List<Product> ProductList { get; }
    }
}