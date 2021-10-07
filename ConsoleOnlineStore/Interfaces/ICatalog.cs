using System.Collections.Generic;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ICatalog
    {
        public List<Product> ProductList { get; }
    }
}