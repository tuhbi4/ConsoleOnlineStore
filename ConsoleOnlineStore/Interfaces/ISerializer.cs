using ConsoleOnlineStore.Models;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer
    {
        public void SaveDataToJson(string fileName, List<Product> productList);
    }
}
