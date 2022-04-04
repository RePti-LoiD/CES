using CES.UXs.Comands;
using CES.Tables;
using CES.Modules.Profile.Users;
using CES.Modules.Profile;

namespace CES.UXs
{
    internal class UX
    {
        private static List<ComandLet> comands = new List<ComandLet>();
        private static User? user;
        private static string? m_userName;
        private static string? m_email;
        private static bool? m_passwordExists;

        internal static void Start()
        {
            Registration();
        }

        #region Save
        private static void SaveUserData()
        {
            Console.WriteLine("Saved success");
        }
        private static void ConfirmSave()
        {

            var yes = new TableItem("Y", "Yes", SaveUserData);
            var no = new TableItem("N", "No");
            TableItem[] tableItems = { yes, no };
            Table.TableHorizontal(tableItems, "Save user profile?");
        }
        #endregion Save

        #region Registration

        private static void Registration()
        {
            var anon = new TableItem("Anonymous registration", "Quit registration, all your messages will be sended by us name.", 
                AnonymousRegistration);
            var partial = new TableItem("Partial registration", "Registration with the indication of email only.", 
                PartialRegistration);
            var full = new TableItem("Full registration", "Complete registration with all the data so that you can send messages on your behalf.", 
                FullRegistration);

            TableItem[] array = { anon, partial, full };
            Table.TableVertical(array, "\tChoose registration type:\n");
        }
        private static void AnonymousRegistration()
        {
            var user = new AnonymousUser();
            UX.user = user;
            Console.WriteLine("You can send messages only of CES email.");
            Thread.Sleep(2000);
            MainPage();
        }
        private static void PartialRegistration()
        {
            Console.WriteLine("Enter your Name and Email");
            Console.Write("Nick:");
            string name = Console.ReadLine() ?? "";
            Console.Write("Email:");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine("Thanks for Registration in CES!\n    Check your mailbox!");
            var user = new PartialUser(name, email);
            UX.user = user;
            Thread.Sleep(2000);
            ConfirmSave();
            MainPage();
        }
        private static void FullRegistration()
        {
            Console.WriteLine("Enter your Name, Email and Password");
            Console.Write("Nick:");
            string name = Console.ReadLine() ?? "";
            Console.Write("Email:");
            string email = Console.ReadLine() ?? "";
            Console.Write("Ok, throw me some numbers:");
            string password = Console.ReadLine() ?? "";
            Console.WriteLine("Thanks for Registration in CES!\n    Check your mailbox!");
            var user = new FullUser(name, email, password);
            UX.user = user;
            Thread.Sleep(2000);
            ConfirmSave();
            MainPage();
        }
        #endregion Registration

        #region Main
        private static void InitComands()
        {
            comands.Clear();
            comands.Add(new ComandLet("Profile", PrintProfile));
        }
        private static void MainPage()
        {
            InitComands();
            string comandName = "";
            Console.WriteLine("Welcome to CES client!");
            do
            {
                Console.Write(":");
                comandName = Console.ReadLine() ?? "";
                SearchMethod(comandName);
            }
            while (comandName != "");
        }
        private static void SearchMethod(string comandName)
        {
            foreach (var comand in comands)
            {
                if (comand.ComandName == comandName)
                {
                    comand.action();
                    break;
                }
            }
        }
        #region DelegateVoid
        private static void PrintProfile()
        {
            (m_userName, m_email, m_passwordExists) = user.OutData;
            Console.Clear();
            Console.WriteLine($"Name: {m_userName}\nEmail: {m_email}\nPassword Exist: {m_passwordExists}");
        }
        #endregion
        
        #endregion
    }
}