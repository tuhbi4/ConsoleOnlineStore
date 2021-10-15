namespace ConsoleOnlineStore.Interfaces.Services
{
    public interface IAccountService
    {
        public bool TryLogIn(string login, string password);

        public bool TryRegister(string login, string password);
    }
}