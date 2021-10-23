using System;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItemHandlers;
using OnlineStoreView.Models.MenuItems;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View.Views.InputViews
{
    public sealed class ProductQuantityInputView : InputView
    {
        private readonly IBasketService basketService;
        private readonly IViewBuffer buffer;
        private bool isSuccess;

        public ProductQuantityInputView(IBasketService basketService, IViewBuffer buffer)
        {
            this.basketService = basketService;
            this.buffer = buffer;
            Header = new("Adding the product to the basket");
            Back = new MenuItemHandler("Cancel", typeof(CatalogMenuView));
            MaxItemIndex = 0;
            WrongIndexMessage = new("Enter correct number");
            MenuItems = new();
        }

        protected override void BeforePrintMenu()
        {
            int addedProductQuantity = 0;
            int maxAllowableQuantity;
            BasketItem intendedBasketItem = buffer.CurrentBasket.BasketItemList.Find(x => x.Product.Name.Contains(buffer.CurrentProduct.Name));

            if (intendedBasketItem != null)
            {
                addedProductQuantity = intendedBasketItem.AddedQuantity;
                maxAllowableQuantity = buffer.CurrentProduct.Quantity - addedProductQuantity;
                MenuItems = new()
                {
                    new InputItem($"Enter quantity (already added: {addedProductQuantity}; still allowable: {maxAllowableQuantity}) "),
                };
            }
            else
            {
                maxAllowableQuantity = buffer.CurrentProduct.Quantity;
                MenuItems = new()
                {
                    new InputItem($"Enter quantity (allowable: {maxAllowableQuantity}) "),
                };
            }
        }

        protected override void OnFinish()
        {
            if (Input == -1)
            {
                if (int.TryParse(MenuItems[0].Input, out int input))
                {
                    int opCode = basketService.TryAddProductToBasket(buffer.CurrentBasket, buffer.CurrentProduct, input);

                    if (opCode == 1)
                    {
                        OnSuccess();
                    }
                    else
                    {
                        OnError(opCode);
                    }
                }
                else
                {
                    Render();
                }
            }
        }

        private void OnSuccess()
        {
            isSuccess = true;
            LineRenderer.Loading("Add a product to the basket...", "", "Success!", ConsoleColor.Green, 2);
        }

        private static void OnError(int opCode)
        {
            if (opCode == 0)
            {
                LineRenderer.Loading("Add a product to the basket...", "", "Wrong quantity.", ConsoleColor.Yellow, 2);
            }
            else
            {
                LineRenderer.Loading("Add a product to the basket...", "", "Product is out of catalog.", ConsoleColor.Red, 2);
            }
        }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            if (isSuccess)
            {
                return typeof(CatalogMenuView);
            }

            return typeof(ProductQuantityInputView);
        }
    }
}