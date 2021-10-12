namespace ConsoleOnlineStore.Models
{
    public class Config
    {
        public const string ConfigJsonPath = @"data\config.json";
        public string ProductsJson { get; set; }
        public string AccountsJson { get; set; }
        public string OrderJson { get; set; }
        public int TimerTimeOut { get; set; }
    }
}