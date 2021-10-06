﻿using ConsoleOnlineStore.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConsoleOnlineStore.Models
{
    public class Deserializer : IDeserializer
    {
        public List<Product> GetDataFromJson(string fileName)
        {
            List<Product> productList = new();
            string jsonString = File.ReadAllText(fileName);
            jsonString = Regex.Replace(jsonString, @"}([^{])*{", @"}}{{");
            string separator = "}{";
            string[] rawObjects = jsonString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string rawObject in rawObjects)
            {
                productList.Add(JsonSerializer.Deserialize<Product>(rawObject));
            }

            return productList;
        }
    }
}