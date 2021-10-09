using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly JsonSerializer jsonSerializer = new();
        private readonly JsonDeserializer jsonDeserializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public void LogIn(string login, string password)
        {
            if (IsAccountMatched(login, password))
            {
                List<Account> accountList = jsonDeserializer.GetAccountList(filepath);
                Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
                accountForMatching.LogIn();
            }
        }

        private bool IsAccountMatched(string login, string password)
        {
            return IsExist(login) && IsMatched(login, password);
        }

        private bool IsMatched(string login, string password)
        {
            List<Account> accountList = jsonDeserializer.GetAccountList(filepath);
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            return accountForMatching.Password == password;
        }

        private bool IsExist(string login)
        {
            List<Account> accountList = jsonDeserializer.GetAccountList(filepath);
            return accountList.Exists(item => item.Login == login);
        }

        public void LogOut(string login)
        {
            List<Account> accountList = jsonDeserializer.GetAccountList(filepath);
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            accountForMatching.LogOut();
        }

        public void Register(string login, string password)
        {
            Account newAccount = new(login, password);
            jsonSerializer.SaveNewAccount(filepath, newAccount);
        }
    }
}