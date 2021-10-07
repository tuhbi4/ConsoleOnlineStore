using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonDeserializer : IDeserializer
    {
        public List<Product> GetData(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return productList;
        }
    }
}