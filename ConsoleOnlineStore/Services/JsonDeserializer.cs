using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonDeserializer<T> : IDeserializer<T>
    {
        public List<T> GetData(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            List<T> itemList = JsonConvert.DeserializeObject<List<T>>(jsonString);

            return itemList;
        }
    }
}