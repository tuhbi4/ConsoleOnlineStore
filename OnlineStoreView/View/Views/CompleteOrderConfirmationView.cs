using System.Collections.Generic;
using ConsoleOnlineStore.Models.Repositories;
using OnlineStoreView.Models;

namespace OnlineStoreView.ZView
{
    public sealed class CompleteOrderConfirmationView : ConfirmationView
    {
        private const string header = "Complete order";

        public CompleteOrderConfirmationView() : base(header)
        {
            Yes = new MenuItemHandler("Yes", typeof(BasketView));
            No = new MenuItemHandler("No", typeof(BasketView));
        }

        protected override void OnFinish()
        {
            List<Product> missingProducts = new();
            storeService.CompleteOrder(out missingProducts);
            // TODO: show a message about the change in the number of products in the catalog
        }
    }
}