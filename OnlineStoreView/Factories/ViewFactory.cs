using System;
using ConsoleOnlineStore.Interfaces.Services;
using OnlineStoreView.Interfaces;
using OnlineStoreView.View.Views.ConfirmationViews;
using OnlineStoreView.View.Views.InputViews;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly IAccountService accountService;
        private readonly IBasketService basketService;
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IViewBuffer buffer;

        public ViewFactory(IAccountService accountService, IBasketService basketService, IOrderService orderService, IProductService productService, IViewBuffer buffer)
        {
            this.accountService = accountService;
            this.basketService = basketService;
            this.orderService = orderService;
            this.productService = productService;
            this.buffer = buffer;
        }

        public IView Create(Type type)
        {
            return type switch
            {
                Type when type == typeof(StartMenuView) => new StartMenuView(),
                Type when type == typeof(MainMenuView) => new MainMenuView(buffer),
                Type when type == typeof(ExitConfirmationView) => new ExitConfirmationView(buffer),
                Type when type == typeof(LogoutConfirmationView) => new LogoutConfirmationView(buffer),
                Type when type == typeof(BasketMenuView) => new BasketMenuView(buffer),
                Type when type == typeof(ClearBasketConfirmationView) => new ClearBasketConfirmationView(buffer),
                Type when type == typeof(OrderDetailsMenuView) => new OrderDetailsMenuView(buffer),
                Type when type == typeof(AuthorizationInputView) => new AuthorizationInputView(accountService, buffer),
                Type when type == typeof(RegistrationInputView) => new RegistrationInputView(accountService, buffer),
                Type when type == typeof(ProductQuantityInputView) => new ProductQuantityInputView(basketService, buffer),
                Type when type == typeof(CompleteOrderConfirmationView) => new CompleteOrderConfirmationView(orderService, buffer),
                Type when type == typeof(OrderHistoryMenuView) => new OrderHistoryMenuView(orderService, buffer),
                Type when type == typeof(CatalogMenuView) => new CatalogMenuView(productService, buffer),
                _ => null,
            };
        }
    }
}