namespace ConsoleOnlineStore.Models.Repositories
{
    public class Account
    {
        public string Login { get; }
        public string Password { get; }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}