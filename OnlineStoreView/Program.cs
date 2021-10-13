using OnlineStoreView.Services;

namespace OnlineStoreView
{
    public static class Program
    {
        private static void Main()
        {
            SwitcherService switcher = new();
            switcher.StartInit();
        }
    }
}