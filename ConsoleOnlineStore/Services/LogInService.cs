using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleOnlineStore.Services
{
    public class LogInService : ILogInService
    {
        private readonly Deserializer deserializer = new();
        private readonly SearchAccountService searchAccountService = new();
        private readonly MatchPasswordService matchPasswordService = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public void LogIn(string login, string password)
        {
            if (IsAccountMatched(login, password))
            {
                List<Account> accountList = deserializer.GetAccountListFromJson(filepath);
                Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
                accountForMatching.LogIn();
            }
        }

        private bool IsAccountMatched(string login, string password)
        {
            return searchAccountService.IsExist(login) && matchPasswordService.IsMatched(login, password);
        }
    }
}