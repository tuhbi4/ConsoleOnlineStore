using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public class ProductQuantityInputMenuViewModel : InputMenuViewModel
    {
        private static readonly string header = "Aadding a product to the basket";

        public ProductQuantityInputMenuViewModel() : base(header)
        {
            Cancel = new HandlerMenuItem("Cancel", typeof(CatalogRepositorySelectionMenuViewModel));
            MenuItems = new()
            {
                new MenuItem("Enter quantity"),
            };
            SuccessHandler = typeof(CatalogRepositorySelectionMenuViewModel);
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