﻿using ConsoleOnlineStore.Interfaces;

namespace ConsoleOnlineStore.Models
{
    public class Product : IProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
