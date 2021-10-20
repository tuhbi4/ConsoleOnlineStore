using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer<T>
    {
        public void SaveData(string filePath, List<T> dataObject);
    }
}