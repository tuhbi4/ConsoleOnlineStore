using ConsoleOnlineStore.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleOnlineStore.Models
{
    public class Serializer : ISerializer
    {
        public void SaveDataToJson(string fileName, List<Product> productList)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            foreach (Product product in productList)
            {
                string jsonString = JsonSerializer.Serialize<Product>(product, options);
                File.AppendAllText(fileName, jsonString + "\r\n");
            }
        }
    }
}