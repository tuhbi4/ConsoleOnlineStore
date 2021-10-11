using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;

namespace ConsoleOnlineStore.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISerializer<T> jsonSerializer;
        private readonly IDeserializer<T> jsonDeserializer;

        public Repository(ISerializer<T> jsonSerializer, IDeserializer<T> jsonDeserializer)
        {
            this.jsonSerializer = jsonSerializer;
            this.jsonDeserializer = jsonDeserializer;
        }

        public void Create(T dataObject)
        {
            jsonSerializer.SaveData(dataObject);
        }

        public void Create(List<T> dataObject)
        {
            jsonSerializer.SaveData(dataObject);
        }

        public List<T> Read()
        {
            return jsonDeserializer.GetData();
        }

        public T Read(int id)
        {
            throw new System.NotImplementedException(); //TODO
        }

        public void Update(int id)
        {
            throw new System.NotImplementedException(); //TODO
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException(); //TODO
        }
    }
}