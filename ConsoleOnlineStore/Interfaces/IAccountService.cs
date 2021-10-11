namespace ConsoleOnlineStore.Interfaces
{
    public interface IAccountService
    {
        public void LogIn(string login, string password);

        public void LogOut(string login);

        public void Register(string login, string password);
    }
}