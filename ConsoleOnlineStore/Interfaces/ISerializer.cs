using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer<T>
    {
        public void SaveData(T dataObject);

        public void SaveData(List<T> dataObject);
    }
}