using System;
using System.Collections.Generic;

namespace OnlineStoreView.Models
{
    public class BasketMenuItemHandler : MenuItemHandler
    {
        public List<ProductMenuItemHandler> ProductList { get; set; }

        public BasketMenuItemHandler(string caption, Type linkedMenuType, List<ProductMenuItemHandler> productList) : base(caption, linkedMenuType)
        {
            ProductList = productList;
        }

        public void UpdateProductQuantity(int index, int quantity)
        {
            ProductList[index].UpdateQuantity(quantity);
        }
    }
}