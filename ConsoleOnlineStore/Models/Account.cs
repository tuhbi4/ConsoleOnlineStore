namespace ConsoleOnlineStore.Models
{
    public class Account
    {
        public int Id { get; }
        public string Login { get; }
        public string Password { get; }
        public bool IsOnline { get; private set; }

        public Account(int id, string login, string password)
        {
            Id = id;
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