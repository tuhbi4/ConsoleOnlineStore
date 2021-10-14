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

        public bool TryLogIn(string login, string password)
        {
            return IsAccountFound(login, password);
        }

        public bool TryRegister(string login, string password)
        {
            if (!IsAccountFound(login, password))
            {
                accountRepository.Create(new Account(login, md5Hash.GetHash(password)));
                return true;
            }

            return false;
        }

        private bool IsAccountFound(string login, string password)
        {
            List<Account> accountList = accountRepository.Read();
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));
            return accountForMatching != null && accountForMatching.Password == md5Hash.GetHash(password);
        }
    }
}