using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IDeserializer
    {
        public List<T> GetData<T>(string filePath);
    }
}