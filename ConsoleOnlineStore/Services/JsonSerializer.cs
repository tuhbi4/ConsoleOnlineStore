using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        public void SaveData(string filePath, T dataObject)
        {
            SaveObject(filePath, dataObject);
        }

        public void SaveData(string filePath, List<T> dataObject)
        {
            SaveObject(filePath, dataObject);
        }

        private void SaveObject(string filePath, object dataObject)
        {
            string jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);
            File.AppendAllText(filePath, jsonString);
        }
    }
}