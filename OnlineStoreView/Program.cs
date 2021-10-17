using OnlineStoreView.ViewModels;

namespace OnlineStoreView
{
    public static class Program
    {
        private static void Main()
        {
            ViewModel viewModel = new();
            viewModel.Init();
        }
    }
}