using ConsoleOnlineStore;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;
using ConsoleOnlineStore.Repository;
using ConsoleOnlineStore.Services;
using OnlineStoreView.Factories;
using OnlineStoreView.Factories.BasketFactories;
using OnlineStoreView.Interfaces;
using OnlineStoreView.View;

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
            IBasketService basketService = new BasketService(productRepository);
            IOrderService orderService = new OrderService(orderRepository, productRepository);
            IProductService productService = new ProductService(productRepository);
            ViewNotifier viewNotifier = new();
            IBasketFactory basketFactory = new NotifiableBasketFactory(viewNotifier, ConfigurationSettings.TimerTimeOut);
            IViewBuffer buffer = new ViewBuffer(basketFactory);
            IViewFactory viewFactory = new ViewFactory(accountService, basketService, orderService, productService, buffer);
            StoreView storeView = new(viewFactory, viewNotifier);
            storeView.Init();
        }
    }
}