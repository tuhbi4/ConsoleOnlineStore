using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Models.Repositories;
using ConsoleOnlineStore.Repository;
using ConsoleOnlineStore.Services;

namespace ConsoleOnlineStore
{
    public static class StoreService
    {
        public static string CurrentUser { get; private set; }

        public static Product CurrentProduct { get; private set; }

        public static Order CurrentOrder { get; private set; }

        private static readonly IDeserializer<Config> configDeserializer = new JsonDeserializer<Config>();
        private static readonly IDeserializer<Product> productDeserializer = new JsonDeserializer<Product>();
        private static readonly ISerializer<Product> productSerializer = new JsonSerializer<Product>();
        private static readonly IDeserializer<Account> accountDeserializer = new JsonDeserializer<Account>();
        private static readonly ISerializer<Account> accountSerializer = new JsonSerializer<Account>();
        private static readonly IDeserializer<Order> orderDeserializer = new JsonDeserializer<Order>();
        private static readonly ISerializer<Order> orderSerializer = new JsonSerializer<Order>();
        private static readonly IHashService hashService = new MD5HashService();
        private static IAccountService accountService;
        private static IBasketService basketService = new BasketService();
        private static IRepository<Product> productRepository;
        private static IRepository<Order> orderRepository;

        static StoreService()
        {
            ConfigurationSettings.LoadSettings(configDeserializer);
            Init();
        }

        private static void Init()
        {
            productRepository = new Repository<Product>(productSerializer, productDeserializer, ConfigurationSettings.ProductsJsonPath);
            IRepository<Account> accountRepository = new Repository<Account>(accountSerializer, accountDeserializer, ConfigurationSettings.AccountsJsonPath);
            orderRepository = new Repository<Order>(orderSerializer, orderDeserializer, ConfigurationSettings.OrderJsonPath);
            accountService = new AccountService(hashService, accountRepository);
        }

        public static int TryLogin(string login, string password)
        {
            int accountState = accountService.TryLogIn(login, password);

            if (accountState == 1)
            {
                CurrentUser = login;
                basketService.InitBasket();
            }

            return accountState;
        }

        public static int TryRegister(string login, string password)
        {
            return accountService.TryRegister(login, password);
        }

        public static void Logout()
        {
            CurrentUser = string.Empty;
            ClearBasket();
        }

        public static List<Product> GetCatalog()
        {
            return productRepository.Read();
        }

        public static void SetCurrentProduct(Product product)
        {
            CurrentProduct = product;
        }

        public static void SetCurrentOrder(Order order)
        {
            CurrentOrder = order;
        }

        public static int TryAddProductToBasket(int quantity)
        {
            List<Product> productList = productRepository.Read();
            Product intendedProduct = productList.Find(x => x.Name.Contains(CurrentProduct.Name));

            if (intendedProduct == null)
            {
                return -2;
            }
            else if (quantity > intendedProduct.Quantity)
            {
                return -1;
            }
            else
            {
                return basketService.TryAddProduct(CurrentProduct, quantity);
            }
        }

        public static List<Product> GetBasket()
        {
            return basketService.GetBasket();
        }

        public static bool CompleteOrder(out List<Product> missingProducts)
        {
            List<Product> catalog = productRepository.Read();
            List<Product> basket = basketService.GetBasket();
            missingProducts = new();

            foreach (Product product in basket)
            {
                Product existingProduct = catalog.Find(x => x.Id.Contains(product.Id));

                if (existingProduct.Quantity < product.Quantity)
                {
                    missingProducts.Add(product);
                }
            }

            if (missingProducts.Count == 0)
            {
                CreateOrder(basket);
                ClearBasket();

                return true;
            }

            return false;
        }

        public static void ClearBasket()
        {
            basketService.ClearBasket();
        }

        public static List<Order> GetOrderHistory()
        {
            return orderRepository.Read();
        }

        private static void CreateOrder(List<Product> productList)
        {
            List<Order> ordertList = orderRepository.Read();
            if (ordertList == null)
            {
                ordertList = new();
            }
            ordertList.Add(new Order(CurrentUser, productList, DateTime.UtcNow));
            orderRepository.Create(ordertList);
        }
    }
}