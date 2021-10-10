using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> GetItemList();

        public T GetItem(int id);

        public void Create(T dataObject);

        public void Update(int id);

        public void Delete(int id);
    }
}