using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Models
{
    public class JsonSerializer : ISerializer
    {
        public void SaveData(string fileName, List<Product> productList)
        {
            string jsonString = JsonConvert.SerializeObject(productList, Formatting.Indented);
            File.AppendAllText(fileName, jsonString);
        }
    }
}