using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        private readonly string filePath;

        public JsonSerializer(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveData(T dataObject)
        {
            SaveObject(dataObject);
        }

        public void SaveData(List<T> dataObject)
        {
            SaveObject(dataObject);
        }

        private void SaveObject(object dataObject)
        {
            string jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);
            File.AppendAllText(filePath, jsonString);
        }
    }
}