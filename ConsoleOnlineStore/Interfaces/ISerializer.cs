using System.Collections.Generic;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer
    {
        public void SaveData(string fileName, List<Product> productList);
    }
}