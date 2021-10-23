using System;
using ConsoleOnlineStore.Models;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.ConfirmationViews;
using OnlineStoreView.View.Views.InputViews;

namespace OnlineStoreView.View.Views.MenuViews
{
    public sealed class BasketMenuView : MenuView<ProductItemHandler>
    {
        private MenuItemHandler Buy { get; }

        private MenuItemHandler Clear { get; }

        private readonly IViewBuffer buffer;

        public BasketMenuView(IViewBuffer buffer)
        {
            this.buffer = buffer;
            Header = new("Basket");
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            MenuItems = new();
            MaxItemIndex = 0;
            Buy = new MenuItemHandler("Buy", typeof(CompleteOrderConfirmationView));
            Clear = new MenuItemHandler("Clear", typeof(ClearBasketConfirmationView));
            WrongIndexMessage = new("Enter correct number");
        }

        protected override void BeforePrintMenu()
        {
            MenuItems = new();
            foreach (BasketItem item in buffer.CurrentBasket.BasketItemList)
            {
                MenuItems.Add(new ProductItemHandler(item.Product, typeof(ProductQuantityInputView)));
            }
        }

        protected override void PrintMenuItems()
        {
            var i = 0;

            if (MenuItems.Count != 0)
            {
                foreach (ProductItemHandler item in MenuItems)
                {
                    LineRenderer.Information($"\n{++i}. {item.Caption}");
                    LineRenderer.Secondary($"   << {item.Product.Description} >>");
                    LineRenderer.Primary($"   Price : {item.Product.Price}");
                    BasketItem intendedBasketItem = buffer.CurrentBasket.BasketItemList.Find(x => x.Product.Name.Contains(item.Product.Name));
                    LineRenderer.Warning($"   Quantity : {intendedBasketItem.AddedQuantity}");
                }

                LineRenderer.Success($"\n{++i}. {Buy.Caption}");
                LineRenderer.Error($"{++i}. {Clear.Caption}");
                MaxItemIndex = MenuItems.Count + 2;
            }
            else
            {
                LineRenderer.Warning("\nYour basket is empty!");
            }
        }

        protected override void OnFinish()
        {
            if (Input != 0 && Input < MenuItems.Count)
            {
                buffer.SetCurrentProduct(MenuItems[Input - 1].Product);
            }
        }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            if (Input == MenuItems.Count + 1)
            {
                return Buy.NextViewType;
            }
            else if (Input == MenuItems.Count + 2)
            {
                return Clear.NextViewType;
            }
            else
            {
                return MenuItems[Input - 1].NextViewType;
            }
        }
    }
}