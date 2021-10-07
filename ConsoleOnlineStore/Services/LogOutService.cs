using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleOnlineStore.Services
{
    public class LogOutService : ILogOutService
    {
        private readonly Deserializer deserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public void LogOut(string login)
        {
            List<Account> accountList = deserializer.GetAccountListFromJson(filepath);
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            accountForMatching.LogOut();
        }
    }
}