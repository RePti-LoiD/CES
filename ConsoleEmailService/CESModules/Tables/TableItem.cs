namespace CES.Tables
{
    internal class TableItem
    {
        public string Label;
        public string Description;
        public delegate void Action();
        public Action action;

        public TableItem(string label, string description) : this(label, description, DelegateNotSet)
        { }
        public TableItem(string label, string description, Action action)
        {
            Label = label;
            Description = description;
            this.action = action;
        }
        private static void DelegateNotSet()
        {
            throw new Exception("Delegate doen't set.");
        }
    }
}
