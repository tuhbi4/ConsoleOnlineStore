using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class LogOutService : ILogOutService
    {
        private readonly JsonDeserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public void LogOut(string login)
        {
            List<Account> accountList = deserializer.GetAccountList(filepath);
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            accountForMatching.LogOut();
        }
    }
}