using System.Collections.Generic;
using ConsoleOnlineStore.Models;

namespace ConsoleOnlineStore.Interfaces
{
    public interface ISerializer
    {
        public void SaveData<T>(T dataObject);
    }
}