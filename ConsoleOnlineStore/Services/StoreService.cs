using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore
{
    public class StoreService
    {
        public string CurrentUser { get; private set; }

        public Product CurrentProduct { get; private set; }

        public Order CurrentOrder { get; private set; }

        private readonly IBasketService basketService;
        private readonly IAccountService accountService;
        private readonly IRepository<Account> accountRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Order> orderRepository;

        public StoreService(IAccountService accountService, IBasketService basketService, IRepository<Account> accountRepository, IRepository<Product> productRepository, IRepository<Order> orderRepository)
        {
            this.accountService = accountService;
            this.basketService = basketService;
            this.accountRepository = accountRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public int TryLogin(string login, string password)
        {
            int accountState = accountService.TryLogIn(login, password);

            if (accountState == 1)
            {
                CurrentUser = login;
                basketService.InitBasket();
            }

            return accountState;
        }

        public int TryRegister(string login, string password)
        {
            return accountService.TryRegister(login, password);
        }

        public void Logout()
        {
            CurrentUser = string.Empty;
            ClearBasket();
        }

        public List<Product> GetCatalog()
        {
            return productRepository.Read();
        }

        public void SetCurrentProduct(Product product)
        {
            CurrentProduct = product;
        }

        public void SetCurrentOrder(Order order)
        {
            CurrentOrder = order;
        }

        public int TryAddProductToBasket(int quantity)
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

        public List<Product> GetBasket()
        {
            return basketService.GetBasket();
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

        public void ClearBasket()
        {
            basketService.ClearBasket();
        }

        public List<Order> GetOrderHistory()
        {
            return orderRepository.Read();
        }

        private void CreateOrder(List<Product> productList)
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