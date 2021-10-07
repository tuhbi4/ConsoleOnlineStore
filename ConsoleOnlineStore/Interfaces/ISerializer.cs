using ConsoleOnlineStore.Models;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer
    {
        public void SaveProductListToJson(string fileName, List<Product> productList);

        public void SaveNewAccountToJson(string fileName, Account newAccount);
    }
}