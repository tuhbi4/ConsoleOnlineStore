using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;

namespace ConsoleOnlineStore.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISerializer<T> jsonSerializer;
        private readonly IDeserializer<T> jsonDeserializer;
        private readonly string filepath;

        public Repository(ISerializer<T> jsonSerializer, IDeserializer<T> jsonDeserializer, string filepath)
        {
            this.jsonSerializer = jsonSerializer;
            this.jsonDeserializer = jsonDeserializer;
            this.filepath = filepath;
        }

        public void Create(List<T> dataObject)
        {
            jsonSerializer.SaveData(filepath, dataObject);
        }

        public List<T> Read()
        {
            return jsonDeserializer.GetData(filepath);
        }
    }
}