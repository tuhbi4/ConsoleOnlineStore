using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IRepository<T>
    {
        public void Create(T dataObject);

        public void Create(List<T> dataObject);

        public List<T> Read();

        public T Read(int id);

        public void Update(int id);

        public void Delete(int id);
    }
}