namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IAccountService
    {
        public int TryLogin(string login, string password);

        public int TryRegister(string login, string password);
    }
}