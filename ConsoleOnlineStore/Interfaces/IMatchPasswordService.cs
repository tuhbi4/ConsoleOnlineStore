namespace ConsoleOnlineStore.Interfaces
{
    public interface IMatchPasswordService
    {
        public bool IsMatched(string login, string password);
    }
}