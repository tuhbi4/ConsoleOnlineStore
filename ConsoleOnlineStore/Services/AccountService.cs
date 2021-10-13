using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> accountRepository;
        private readonly IHashService md5Hash;

        public AccountService(IHashService md5Hash, IRepository<Account> accountRepository)
        {
            this.md5Hash = md5Hash;
            this.accountRepository = accountRepository;
        }

        public void LogIn(string login, string password)
        {
            if (IsAccountMatched(login, password))
            {
                List<Account> accountList = accountRepository.Read();
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
            List<Account> accountList = accountRepository.Read();
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            return accountForMatching.Password == md5Hash.GetHash(password);
        }

        private bool IsExist(string login)
        {
            List<Account> accountList = accountRepository.Read();
            return accountList.Exists(item => item.Login == login);
        }

        public void LogOut(string login)
        {
            List<Account> accountList = accountRepository.Read();
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            accountForMatching.LogOut();
        }

        public void Register(string login, string password)
        {
            Account newAccount = new(Guid.NewGuid(), login, md5Hash.GetHash(password));
            accountRepository.Create(newAccount);
        }
    }
}