using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class MatchPasswordService : IMatchPasswordService
    {
        private readonly JsonDeserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public bool IsMatched(string login, string password)
        {
            List<Account> accountList = deserializer.GetAccountList(filepath);
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            return accountForMatching.Password == password;
        }
    }
}