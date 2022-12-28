using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Models.Repositories;

namespace ConsoleOnlineStore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Product> productRepository;

        public BasketService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public int TryAddProductToBasket(Basket basket, Product product, int quantity)
        {
            List<Product> productList = productRepository.Read();
            Product intendedProduct = productList.Find(x => x.Name.Contains(product.Name));
            BasketItem addedProduct = basket.BasketItemList.Find(x => x.Product.Name.Contains(product.Name));

            if (intendedProduct == null)
            {
                return -1;
            }
            else if ((addedProduct == null && quantity <= intendedProduct.Quantity && quantity >= 1)
                || (addedProduct != null && quantity <= intendedProduct.Quantity - addedProduct.AddedQuantity))
            {
                basket.AddProduct(product, quantity);

                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}