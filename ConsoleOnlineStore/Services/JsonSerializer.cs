﻿using System.Collections.Generic;
using System.IO;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Models;
using Newtonsoft.Json;

namespace ConsoleOnlineStore.Services
{
    public class JsonSerializer : ISerializer
    {
        public void SaveProductList(string fileName, List<Product> productList)
        {
            string jsonString = JsonConvert.SerializeObject(productList, Formatting.Indented);
            File.AppendAllText(fileName, jsonString);
        }

        public void SaveNewAccount(string fileName, Account newAccount)
        {
            string jsonString = JsonConvert.SerializeObject(newAccount, Formatting.Indented);
            File.AppendAllText(fileName, jsonString);
        }
    }
}