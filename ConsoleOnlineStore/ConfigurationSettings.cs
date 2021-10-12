using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore
{
    public static class ConfigurationSettings

    {
        public static string ProductsJson { get; private set; }
        public static string AccountsJson { get; private set; }
        public static string OrderJson { get; private set; }
        public static int TimerTimeOut { get; private set; }

        public static void LoadSettings(IDeserializer<Config> configJsonDeserializer)
        {
            var configList = configJsonDeserializer.GetData();
            ProductsJson = configList[0].ProductsJson;
            AccountsJson = configList[0].AccountsJson;
            OrderJson = configList[0].OrderJson;
            TimerTimeOut = configList[0].TimerTimeOut;
        }
    }
}