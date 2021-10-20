using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Models.Repositories;
using ConsoleOnlineStore.Repository;
using ConsoleOnlineStore.Services;

namespace ConsoleOnlineStore
{
    public class StoreService
    {
        private readonly IDeserializer<Config> configDeserializer = new JsonDeserializer<Config>();
        private readonly IDeserializer<Product> productDeserializer = new JsonDeserializer<Product>();
        private readonly ISerializer<Product> productSerializer = new JsonSerializer<Product>();
        private readonly IDeserializer<Account> accountDeserializer = new JsonDeserializer<Account>();
        private readonly ISerializer<Account> accountSerializer = new JsonSerializer<Account>();
        private readonly IDeserializer<Order> orderDeserializer = new JsonDeserializer<Order>();
        private readonly ISerializer<Order> orderSerializer = new JsonSerializer<Order>();
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly IHashService hashService = new MD5HashService();
        private readonly IAccountService accountService;
        private readonly IBasketService basketService = new BasketService();
        private string currentUser;

        public StoreService()
        {
            ConfigurationSettings.LoadSettings(configDeserializer);
            productRepository = new Repository<Product>(productSerializer, productDeserializer, ConfigurationSettings.ProductsJsonPath);
            IRepository<Account> accountRepository = new Repository<Account>(accountSerializer, accountDeserializer, ConfigurationSettings.AccountsJsonPath);
            orderRepository = new Repository<Order>(orderSerializer, orderDeserializer, ConfigurationSettings.OrderJsonPath);
            accountService = new AccountService(hashService, accountRepository);
        }

        public int TryLogin(string login, string password)
        {
            int accountState = accountService.TryLogIn(login, password);
            if (accountState == 1)
            {
                currentUser = login;
            }
            return accountState;
        }

        public int TryRegister(string login, string password)
        {
            return accountService.TryRegister(login, password);
        }

        public void Logout()
        {
            currentUser = string.Empty;
            ClearBasket();
        }

        public List<Product> GetCatalog()
        {
            return productRepository.Read();
        }

        public int TryAddProductToBasket(Product product, int quantity)
        {
            List<Product> productList = productRepository.Read();
            Product intendedProduct = productList.Find(x => x.Name.Contains(product.Name));

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
                return basketService.TryAddProduct(product, quantity);
            }
        }

        public bool CompleteOrder(out List<Product> missingProducts)
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

        public List<Order> GetOrderHistory()
        {
            return orderRepository.Read();
        }

        private void CreateOrder(List<Product> productList)
        {
            orderRepository.Create(new Order(currentUser, productList));
        }

        public void ClearBasket()
        {
            basketService.ClearBasket();
        }
    }
}