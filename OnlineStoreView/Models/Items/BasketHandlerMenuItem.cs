using System;
using System.Collections.Generic;

namespace OnlineStoreView.Models
{
    public class BasketHandlerMenuItem : HandlerMenuItem
    {
        public List<ProductHandlerMenuItem> ProductList { get; set; }

        public BasketHandlerMenuItem(string caption, Type linkedMenuType, List<ProductHandlerMenuItem> productList) : base(caption, linkedMenuType)
        {
            ProductList = productList;
        }

        public void UpdateProductQuantity(int index, int quantity)
        {
            ProductList[index].UpdateQuantity(quantity);
        }
    }
}