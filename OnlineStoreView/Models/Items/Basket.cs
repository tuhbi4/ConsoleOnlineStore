using System;
using System.Collections.Generic;

namespace OnlineStoreView.Models
{
    public class Basket : Link
    {
        public List<ProductLink> ProductList { get; set; }

        public Basket(string caption, Type linkedMenuType, List<ProductLink> productList) : base(caption, linkedMenuType)
        {
            ProductList = productList;
        }

        public void UpdateProductQuantity(int index, int quantity)
        {
            ProductList[index].UpdateQuantity(quantity);
        }
    }
}