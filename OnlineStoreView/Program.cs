using OnlineStoreView.Views;

namespace OnlineStoreView
{
    public static class Program
    {
        private static void Main()
        {
            StoreView viewModel = new();
            viewModel.Init();
        }
    }
}