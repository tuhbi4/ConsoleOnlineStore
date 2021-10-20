using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;

namespace ConsoleOnlineStore.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISerializer jsonSerializer;
        private readonly IDeserializer jsonDeserializer;
        private readonly string filepath;

        public Repository(ISerializer jsonSerializer, IDeserializer jsonDeserializer, string filepath)
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
            return jsonDeserializer.GetData<T>(filepath);
        }
    }
}