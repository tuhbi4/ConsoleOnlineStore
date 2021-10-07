using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class SearchAccountService : ISearchAccountService
    {
        private readonly JsonDeserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public bool IsExist(string login)
        {
            List<Account> accountList = deserializer.GetAccountList(filepath);
            return accountList.Exists(item => item.Login == login);
        }
    }
}