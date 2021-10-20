using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonSerializer : ISerializer
    {
        public void SaveData<T>(string filePath, List<T> dataObject)
        {
            string jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }
    }
}