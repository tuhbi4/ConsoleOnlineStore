using System.IO;
using ConsoleOnlineStore.Interfaces;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonSerializer : ISerializer
    {
        private readonly string filePath;

        public JsonSerializer(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveData<T>(T dataObject)
        {
            string jsonString = JsonConvert.SerializeObject(dataObject, Formatting.Indented);
            File.AppendAllText(filePath, jsonString);
        }
    }
}