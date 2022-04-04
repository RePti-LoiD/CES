namespace CES.CESModules.Profile
{
    static class SingletonHolder
    {
        public static Singleton instance;
    }
    class Singleton
    {
        private static Singleton? instance;

        public string Name { get; private set; }

        protected Singleton(string name)
        {
            Name = name;
        }
        public static Singleton getInstance(string name)
        {
            if (instance == null)
                instance = new Singleton(name);
            return instance;
        }
        public void Args(string[] args)
        {
            foreach (var item in args)
            {
                Console.WriteLine(item);
            }
        }
    }
    class SingletonExtends : Singleton
    {
        
        
        protected SingletonExtends(string name) : base(name)
        {

        }
    }
}
