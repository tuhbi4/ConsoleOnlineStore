using ConsoleOnlineStore;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;
using ConsoleOnlineStore.Repository;
using ConsoleOnlineStore.Services;
using OnlineStoreView.Views;

namespace OnlineStoreView
{
    public static class Program
    {
        private static void Main()
        {
            IDeserializer JsonDeserializer = new JsonDeserializer();
            ConfigurationSettings.LoadSettings(JsonDeserializer);
            ISerializer JsonSerializer = new JsonSerializer();
            IRepository<Account> accountRepository = new Repository<Account>(JsonSerializer, JsonDeserializer, ConfigurationSettings.AccountsJsonPath);
            IRepository<Product> productRepository = new Repository<Product>(JsonSerializer, JsonDeserializer, ConfigurationSettings.ProductsJsonPath);
            IRepository<Order> orderRepository = new Repository<Order>(JsonSerializer, JsonDeserializer, ConfigurationSettings.OrderJsonPath);
            IHashService hashService = new MD5HashService();
            IAccountService accountService = new AccountService(hashService, accountRepository);
            IBasketService basketService = new BasketService();
            StoreService storeService = new(accountService, basketService, accountRepository, productRepository, orderRepository);
            StoreView storeView = new(storeService);
            storeView.Init();
        }
    }
}