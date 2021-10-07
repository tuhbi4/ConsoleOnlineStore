using ConsoleOnlineStore.Models;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer
    {
        public abstract void SaveData(string fileName, List<Product> productList);
    }
}