namespace OnlineStoreView.Models
{
    public class MenuItem
    {
        public string Caption { get; protected set; }

        public MenuItem(string caption)
        {
            Caption = caption;
        }
    }
}