namespace OnlineStoreView.ZView
{
    public class MenuItemHandler : MenuItem
    {
        public ViewType NextView { get; }

        public MenuItemHandler(string caption, ViewType nextView) : base(caption)
        {
            NextView = nextView;
        }
    }
}