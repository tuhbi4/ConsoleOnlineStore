using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IRepository<T>
    {
        public void Create(T dataObject);

        public void Create(List<T> dataObject); //TODO: remove useless method?

        public List<T> Read();

        public T Read(int id); //TODO: remove useless method?

        public void Update(int id); //TODO: remove useless method?

        public void Delete(int id); //TODO: remove useless method?
    }
}