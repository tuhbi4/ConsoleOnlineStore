using OnlineStoreView.Services;

namespace OnlineStoreView.Models
{
    public class ReguestQuantityForm : ResponseForm
    {
        private static readonly string header = "Aadding a product to the basket";

        public ReguestQuantityForm() : base(header)
        {
            MenuItems = new()
            {
                new Span("Enter quantity"),
            };
            LinkedSuccessMenu = typeof(CatalogService);
            LinkedErrorMenu = typeof(ReguestQuantityForm);
        }

        protected override void OnFinish()
        {
            CalledType = LinkedSuccessMenu; // TODO: implement call to account repository with success
        }
    }
}