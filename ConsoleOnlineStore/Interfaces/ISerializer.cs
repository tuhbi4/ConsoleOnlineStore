using System.Collections.Generic;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer
    {
        public void SaveProductList(string fileName, List<Product> productList);

        public void SaveNewAccount(string fileName, Account newAccount);
    }
}