

namespace CES.UXs.Comands
{
    internal struct ComandLet
    {
        internal string ComandName;
        internal delegate void Action();
        internal Action action;

        public ComandLet(string name, Action action)
        {
            ComandName = name;
            this.action = action;
        }
    }
}
