using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore
{
    public static class ConfigurationSettings

    {
        private const string ConfigJsonPath = "..\\..\\..\\..\\ConsoleOnlineStore\\config\\config.json";

        public static string ProductsJsonPath { get; private set; }

        public static string AccountsJsonPath { get; private set; }

        public static string OrderJsonPath { get; private set; }

        public static int TimerTimeOut { get; private set; }

        public static void LoadSettings(IDeserializer configJsonDeserializer)
        {
            List<Config> configList = configJsonDeserializer.GetData<Config>(ConfigJsonPath);
            ProductsJsonPath = configList[0].ProductsJsonPath;
            AccountsJsonPath = configList[0].AccountsJsonPath;
            OrderJsonPath = configList[0].OrderJsonPath;
            TimerTimeOut = configList[0].TimerTimeOut;
        }
    }
}