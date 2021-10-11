using System.Collections.Generic;
using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Repository;

namespace ConsoleOnlineStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly Repository<Account> accountsRepository = new(ConfigurationManager.AppSettings.Get("accountsJson"));

        public void LogIn(string login, string password)
        {
            if (IsAccountMatched(login, password))
            {
                List<Account> accountList = accountsRepository.GetItemList();
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
            MD5HashService md5Hash = new();
            List<Account> accountList = accountsRepository.GetItemList();
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            return accountForMatching.Password == md5Hash.GetHash(password);
        }

        private bool IsExist(string login)
        {
            List<Account> accountList = accountsRepository.GetItemList();
            return accountList.Exists(item => item.Login == login);
        }

        public void LogOut(string login)
        {
            List<Account> accountList = accountsRepository.GetItemList();
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            accountForMatching.LogOut();
        }

        public void Register(string login, string password)
        {
            MD5HashService md5Hash = new();
            Account newAccount = new(login, md5Hash.GetHash(password));
            accountsRepository.Create(newAccount);
        }
    }
}