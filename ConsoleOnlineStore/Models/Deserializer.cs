using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ConsoleOnlineStore.Models
{
    public class Deserializer : IDeserializer
    {
        public List<Product> GetDataFromJson(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            List<Product> productList = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return productList;
        }
    }
}