using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Services;

namespace ConsoleOnlineStore.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISerializer jsonSerializer;
        private readonly IDeserializer<T> jsonDeserializer;

        public Repository(ISerializer jsonSerializer, IDeserializer<T> jsonDeserializer)
        {
            this.jsonSerializer = jsonSerializer;
            this.jsonDeserializer = jsonDeserializer;
        }

        public List<T> GetItemList()
        {
            return jsonDeserializer.GetData();
        }

        public T GetItem(int id)
        {
            throw new System.NotImplementedException(); //TODO
        }

        public void Create(T dataObject)
        {
            jsonSerializer.SaveData(dataObject);
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