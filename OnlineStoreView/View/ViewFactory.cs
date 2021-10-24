using System;
using ConsoleOnlineStore.Interfaces.Services;
using OnlineStoreView.Interfaces;
using OnlineStoreView.View.Views.ConfirmationViews;
using OnlineStoreView.View.Views.InputViews;
using OnlineStoreView.View.Views.MenuViews;

namespace OnlineStoreView.View
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
            switch (type)
            {
                case Type when type == typeof(StartMenuView):
                    return new StartMenuView();

                case Type when type == typeof(MainMenuView):
                    return new MainMenuView(buffer);

                case Type when type == typeof(ExitConfirmationView):
                    return new ExitConfirmationView(buffer);

                case Type when type == typeof(LogoutConfirmationView):
                    return new LogoutConfirmationView(buffer);

                case Type when type == typeof(BasketMenuView):
                    return new BasketMenuView(buffer);

                case Type when type == typeof(ClearBasketConfirmationView):
                    return new ClearBasketConfirmationView(buffer);

                case Type when type == typeof(OrderDetailsMenuView):
                    return new OrderDetailsMenuView(buffer);

                case Type when type == typeof(AuthorizationInputView):
                    return new AuthorizationInputView(accountService, buffer);

                case Type when type == typeof(RegistrationInputView):
                    return new RegistrationInputView(accountService, buffer);

                case Type when type == typeof(ProductQuantityInputView):
                    return new ProductQuantityInputView(basketService, buffer);

                case Type when type == typeof(CompleteOrderConfirmationView):
                    return new CompleteOrderConfirmationView(orderService, buffer);

                case Type when type == typeof(OrderHistoryMenuView):
                    return new OrderHistoryMenuView(orderService, buffer);

                case Type when type == typeof(CatalogMenuView):
                    return new CatalogMenuView(productService, buffer);

                default:
                    return null;
            }
        }
    }
}