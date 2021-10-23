namespace OnlineStoreView.Models.MenuItems
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

    public class Request
    {
        public string Statement { get; }

        public string Expression { get; private set; }

        public Request(string statement)
        {
            Statement = statement;
            Expression = string.Empty;
        }

        public void SetExpression(string expression)
        {
            Expression = expression;
        }
    }
}