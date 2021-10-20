namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IAccountService
    {
        public int TryLogIn(string login, string password);

        public int TryRegister(string login, string password);
    }
}