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

        public void Create(T dataObject)
        {
            jsonSerializer.SaveData(filepath, dataObject);
        }

        public void Create(List<T> dataObject) //TODO: remove useless method?
        {
            jsonSerializer.SaveData(filepath, dataObject);
        }

        public List<T> Read()
        {
            return jsonDeserializer.GetData(filepath);
        }

        public T Read(int id) //TODO: remove useless method?
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id) //TODO: remove useless method?
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id) //TODO: remove useless method?
        {
            throw new System.NotImplementedException();
        }
    }
}