namespace ConsoleOnlineStore.Models
{
    public class Account
    {
        public string Login { get; }
        public string Password { get; }
        public bool IsOnline { get; private set; }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public void LogIn()
        {
            IsOnline = true;
        }

        public void LogOut()
        {
            IsOnline = false;
        }
    }
}