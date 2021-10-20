using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IRepository<T>
    {
        public void Create(List<T> dataObject);

        public List<T> Read();
    }
}