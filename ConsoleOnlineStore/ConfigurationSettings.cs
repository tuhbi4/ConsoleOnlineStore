using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Services;

namespace ConsoleOnlineStore
{
    public static class ConfigurationSettings

    {
        private static readonly JsonDeserializer<Config> timerJsonDeserializer = new(Config.ConfigJsonPath);

        public static string ProductsJson { get; private set; }
        public static string AccountsJson { get; private set; }
        public static string OrderJson { get; private set; }
        public static int TimerTimeOut { get; private set; }

        public static void LoadSettings()
        {
            var configList = timerJsonDeserializer.GetData();
            ProductsJson = configList[0].ProductsJson;
            AccountsJson = configList[0].AccountsJson;
            OrderJson = configList[0].OrderJson;
            TimerTimeOut = configList[0].TimerTimeOut;
        }
    }
}