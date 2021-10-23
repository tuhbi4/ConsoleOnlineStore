using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> accountRepository;
        private readonly IHashService md5Hash;
        private List<Account> accountList;

        public AccountService(IHashService md5Hash, IRepository<Account> accountRepository)
        {
            this.md5Hash = md5Hash;
            this.accountRepository = accountRepository;
        }

        public int TryLogin(string login, string password)
        {
            accountList = accountRepository.Read();

            if (IsAccountFound(login, password))
            {
                return 1;
            }
            else if (IsLoginExist(login))
            {
                return 0;
            }

            return -1;
        }

        public int TryRegister(string login, string password)
        {
            accountList = accountRepository.Read();

            if (!IsAccountFound(login, password))
            {
                accountList.Add(new Account(login, md5Hash.GetHash(password)));
                accountRepository.Create(accountList);

                return 1;
            }
            else if (IsLoginExist(login))
            {
                return 0;
            }

            return -1;
        }

        private bool IsAccountFound(string login, string password)
        {
            if (accountList != null && login != null && password != null)
            {
                Account accountForMatching = accountList.Find(x => x.Login.Contains(login));

                return accountForMatching != null && accountForMatching.Password == md5Hash.GetHash(password);
            }

            return false;
        }

        private bool IsLoginExist(string login)
        {
            if (accountList != null)
            {
                return accountList.Exists(item => item.Login == login);
            }

            return false;
        }
    }
}