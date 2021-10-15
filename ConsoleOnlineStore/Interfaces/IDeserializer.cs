using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IDeserializer<T>
    {
        public List<T> GetData(string filePath);
    }
}