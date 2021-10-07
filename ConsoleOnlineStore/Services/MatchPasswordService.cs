using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleOnlineStore.Services
{
    public class MatchPasswordService : IMatchPasswordService
    {
        private readonly Deserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public bool IsMatched(string login, string password)
        {
            List<Account> accountList = deserializer.GetAccountListFromJson(filepath);
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            return accountForMatching.Password == password;
        }
    }
}