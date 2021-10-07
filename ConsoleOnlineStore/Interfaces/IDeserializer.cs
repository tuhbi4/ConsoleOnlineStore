using System.Collections.Generic;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IDeserializer
    {
        public List<Product> GetData(string fileName);
    }
}