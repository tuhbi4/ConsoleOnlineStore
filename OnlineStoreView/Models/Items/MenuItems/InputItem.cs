namespace OnlineStoreView.ZView
{
    public class InputItem : MenuItem
    {
        public string Input { get; private set; }

        public InputItem(string caption) : base(caption) { }

        public void SetInput(string input)
        {
            Input = input;
        }

    }
}