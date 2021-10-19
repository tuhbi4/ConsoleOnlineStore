using OnlineStoreView.Models;

namespace OnlineStoreView.Views
{
    public class ProductQuantityInputMenuViewModel : InputView
    {
        private static readonly string header = "Aadding a product to the basket";

        public ProductQuantityInputMenuViewModel() : base(header)
        {
            Cancel = new MenuItemHandler("Cancel", typeof(CatalogView));
            MenuItems = new()
            {
                new MenuItem("Enter quantity"),
            };
            SuccessHandler = typeof(CatalogView);
            ErrorHandler = typeof(ProductQuantityInputMenuViewModel);
        }

        protected override void OnFinish()
        {
            if (true) // TODO: implement call to product repository
            {
                OnSuccess();
            }
            else
            {
                OnError();
            }
        }
    }
}