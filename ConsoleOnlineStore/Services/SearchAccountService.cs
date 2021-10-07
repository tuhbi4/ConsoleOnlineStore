using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleOnlineStore.Services
{
    public class SearchAccountService : ISearchAccountService
    {
        private readonly Deserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public bool IsExist(string login)
        {
            List<Account> accountList = deserializer.GetAccountListFromJson(filepath);
            return accountList.Exists(item => item.Login == login);
        }
    }
}