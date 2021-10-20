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

        public AccountService(IHashService md5Hash, IRepository<Account> accountRepository)
        {
            this.md5Hash = md5Hash;
            this.accountRepository = accountRepository;
        }

        public int TryLogIn(string login, string password)
        {
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
            if (!IsAccountFound(login, password))
            {
                accountRepository.Create(new Account(login, md5Hash.GetHash(password)));

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
            List<Account> accountList = accountRepository.Read();
            Account accountForMatching = accountList.Find(x => x.Login.Contains(login));

            return accountForMatching != null && accountForMatching.Password == md5Hash.GetHash(password);
        }

        private bool IsLoginExist(string login)
        {
            List<Account> accountList = accountRepository.Read();

            return accountList.Exists(item => item.Login == login);
        }
    }
}