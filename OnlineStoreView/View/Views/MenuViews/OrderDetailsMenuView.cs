using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItems;
using OnlineStoreView.Models.MenuItems.MenuItemHandlers;
using OnlineStoreView.Renderers;

namespace OnlineStoreView.View.Views.MenuViews
{
    public sealed class OrderDetailsMenuView : MenuView<ProductItem>
    {
        private readonly IViewBuffer buffer;

        public OrderDetailsMenuView(IViewBuffer buffer)
        {
            this.buffer = buffer;

            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = new();
            MaxItemIndex = 0;
            WrongIndexMessage = new("Enter correct number");
        }

        protected override void BeforePrintMenu()
        {
            Header = new($"Order details from {buffer.CurrentOrder.PurchaseDate.ToLocalTime() }:");
            List<Product> productList = buffer.CurrentOrder.ProductList;
            MenuItems = new();

            foreach (Product product in productList)
            {
                MenuItems.Add(new ProductItem(product));
            }
        }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            return null;
        }

        protected override void OnFinish() { }

        protected override void PrintMenuItems()
        {
            var i = 1;

            foreach (ProductItem item in MenuItems)
            {
                LineRenderer.Secondary($"\n      {i++}");
                LineRenderer.Warning($"          Name : {item.Product.Name}");
                LineRenderer.Primary($"   Description : {item.Product.Description}");
                LineRenderer.Primary($"         Price : {item.Product.Price}");
                LineRenderer.Primary($"      Quantity : {item.Product.Quantity}");
            }
        }
    }
}