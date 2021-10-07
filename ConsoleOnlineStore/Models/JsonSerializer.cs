using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ConsoleOnlineStore.Models
{
    public class JsonSerializer : ISerializer
    {
        public virtual void SaveData(string fileName, List<Product> productList)
        {
            string jsonString = JsonConvert.SerializeObject(productList, Formatting.Indented);
            File.AppendAllText(fileName, jsonString);
        }
    }
}