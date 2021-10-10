using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Services;

namespace ConsoleOnlineStore.Repository
{
    public class Repository<T> : IRepository<T>
    {
        private readonly JsonSerializer jsonSerializer;
        private readonly JsonDeserializer<T> jsonDeserializer;

        public Repository(string filePath)
        {
            jsonSerializer = new(filePath);
            jsonDeserializer = new(filePath);
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