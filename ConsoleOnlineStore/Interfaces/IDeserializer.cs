using ConsoleOnlineStore.Models;
using System.Collections.Generic;

namespace ConsoleOnlineStore.Interfaces
{
    public interface IDeserializer
    {
        public List<Product> GetDataFromJson(string fileName);
    }
}