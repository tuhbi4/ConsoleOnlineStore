using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonDeserializer : IDeserializer
    {
        public List<T> GetData<T>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            List<T> itemList = JsonConvert.DeserializeObject<List<T>>(jsonString);

            return itemList;
        }
    }
}