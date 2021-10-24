using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer
    {
        public void SaveData<T>(string filePath, List<T> dataObject);
    }
}