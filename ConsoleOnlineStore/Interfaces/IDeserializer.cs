using ConsoleOnlineStore.Models;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IDeserializer
    {
        public List<Product> GetProductListFromJson(string fileName);

        public List<Account> GetAccountListFromJson(string fileName);

        public int GetTimerFromJson(string fileName);
    }
}