using System.Collections.Generic;

namespace ConsoleOnlineStore.Models.Repositories
{
    public class Basket
    {
        public string AccountLogin { get; }

        public List<BasketItem> BasketItemList { get; private set; }

        public Basket(string accountLogin)
        {
            AccountLogin = accountLogin;
            BasketItemList = new();
        }

        public List<Product> GetProducts()
        {
            List<Product> productList = new();
            foreach (BasketItem item in BasketItemList)
            {
                productList.Add(item.Product);
            }
            return productList;
        }

        public void AddProduct(Product product, int quantity)
        {
            BasketItem existingProduct = BasketItemList.Find(x => x.Product.Id.Contains(product.Id));

            if (existingProduct != null)
            {
                existingProduct.AddedQuantity += quantity;
            }
            else
            {
                BasketItemList.Add(new BasketItem() { Product = product, AddedQuantity = quantity });
                product.Quantity = quantity;
            }
        }

        public void ClearBasket()
        {
            BasketItemList.Clear();
        }
    }
}