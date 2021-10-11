using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonDeserializer<T> : IDeserializer<T>
    {
        private readonly string filePath;

        public JsonDeserializer(string filePath)
        {
            this.filePath = filePath;
        }

        public List<T> GetData()
        {
            string jsonString = File.ReadAllText(filePath);
            List<T> itemList = JsonConvert.DeserializeObject<List<T>>(jsonString);
            return itemList;
        }
    }
}