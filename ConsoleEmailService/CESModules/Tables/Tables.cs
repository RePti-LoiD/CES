namespace CES.Tables
{
    internal class Table
    {
        #region Internal

        internal static void TableVertical(TableItem[] nameArray, string message)
        {
            DrawTable(nameArray, 0, message);
            bool run = true;
            int index = 0;
            while (run)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        DrawTable(nameArray, ChangeIndex(ref index, -1, nameArray.Length - 1, 0), message);
                        break;
                    case ConsoleKey.DownArrow:
                        DrawTable(nameArray, ChangeIndex(ref index, 1, nameArray.Length - 1, 0), message);
                        break;
                    case ConsoleKey.Enter:
                        nameArray[index].action();
                        run = false;
                        break;
                }
            }
            Console.ResetColor();
            Console.Clear();
        }
        internal static void TableHorizontal(TableItem[] nameArray, string message)
        {
            DrawTableHorizontal(nameArray, 0, message);
            bool run = true;
            int index = 0;
            while (run)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        DrawTableHorizontal(nameArray, ChangeIndex(ref index, -1, nameArray.Length - 1, 0), message);
                        break;
                    case ConsoleKey.RightArrow:
                        DrawTableHorizontal(nameArray, ChangeIndex(ref index, 1, nameArray.Length - 1, 0), message);
                        break;
                    case ConsoleKey.Enter:
                        nameArray[index].action();
                        run = false;
                        break;
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                }
            }
            Console.ResetColor();
            Console.Clear();
        }
        #endregion Internal

        #region Private
        private static int ChangeIndex(ref int current, int amount, int highBound, int lowerBound = 0)
        {
            current = Math.Clamp(current += amount, lowerBound, highBound);
            return current;
        }
        private static void DrawActionTab(TableItem item)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(item.Label);
            Console.ResetColor();
            Console.Write("\t" + item.Description);
            Console.WriteLine();
        }
        private static void DrawTable(TableItem[] tableArray, int actionIndex, string message)
        {
            Console.Clear();
            if (message != "")
            {
                Console.WriteLine(message);
            }
            for (int i = 0; i < actionIndex; i++)
            {
                Console.WriteLine(tableArray[i].Label);
            }
            DrawActionTab(tableArray[actionIndex]);
            for (int i = actionIndex + 1; i < tableArray.Length; i++)
            {
                Console.WriteLine(tableArray[i].Label);
            }
        }
        private static void DrawTableHorizontal(TableItem[] tableArray, int actionIndex, string message = "")
        {
            Console.Clear();
            if (message != "")
            {
                Console.WriteLine(message);
            }
            for (int i = 0; i < tableArray.Length; i++)
            {
                if (i == actionIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"   {tableArray[i].Label}   ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("   " + tableArray[i].Label + "   ");
                }
            }
        }

        /// <summary>
        /// Wait realization.
        /// </summary>
        private static void DrawTableWithContent()
        {

        }

        #endregion Private
    }
}
