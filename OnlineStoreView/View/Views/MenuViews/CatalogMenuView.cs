using System;
using System.Collections.Generic;
using ConsoleOnlineStore.Interfaces.Services;
using ConsoleOnlineStore.Models;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Interfaces;
using OnlineStoreView.Models.MenuItems.MenuItemHandlers;
using OnlineStoreView.Renderers;
using OnlineStoreView.View.Views.InputViews;

namespace OnlineStoreView.View.Views.MenuViews
{
    public sealed class CatalogMenuView : MenuView<ProductItemHandler>
    {
        private readonly IViewBuffer buffer;

        public CatalogMenuView(IProductService productService, IViewBuffer buffer)
        {
            this.buffer = buffer;
            Header = new("Catalog");
            Back = new MenuItemHandler("Back", typeof(MainMenuView));
            List<Product> productList = productService.GetCatalog();
            MaxItemIndex = productList.Count;
            MenuItems = new();

            foreach (Product product in productList)
            {
                MenuItems.Add(new ProductItemHandler(product, typeof(ProductQuantityInputView)));
            }

            MaxItemIndex = MenuItems.Count;
            WrongIndexMessage = new("Enter correct number");
        }

        protected override void BeforePrintMenu() { }

        protected override Type GetNextViewTypeWhenIsNotBackItem()
        {
            return MenuItems[Input - 1].NextViewType;
        }

        protected override void OnFinish()
        {
            if (Input != 0)
            {
                buffer.SetCurrentProduct(MenuItems[Input - 1].Product);
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
                    int addedProductQuantity = 0;
                    BasketItem intendedBasketItem = buffer.CurrentBasket.BasketItemList.Find(x => x.Product.Name.Contains(item.Product.Name));

                    if (intendedBasketItem != null)
                    {
                        addedProductQuantity = intendedBasketItem.AddedQuantity;
                        LineRenderer.Warning($"   In stock : {item.Product.Quantity} (already added: {addedProductQuantity})");
                    }
                    else
                    {
                        LineRenderer.Warning($"   In stock : {item.Product.Quantity}");
                    }
                }
            }
            else
            {
                LineRenderer.Warning("\nSorry, but we are not selling anything right now =(");
            }
        }
    }
}