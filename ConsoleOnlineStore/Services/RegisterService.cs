using System.Configuration;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly JsonSerializer serializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public void Register(string login, string password)
        {
            Account newAccount = new(login, password);
            serializer.SaveNewAccount(filepath, newAccount);
        }
    }
}