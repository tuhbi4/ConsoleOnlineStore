using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using System.Configuration;

namespace ConsoleOnlineStore.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly Serializer serializer = new();
        private readonly string filepath = ConfigurationManager.AppSettings.Get("accountsDatabase");

        public void Register(string login, string password)
        {
            Account newAccount = new(login, password);
            serializer.SaveNewAccountToJson(filepath, newAccount);
        }
    }
}