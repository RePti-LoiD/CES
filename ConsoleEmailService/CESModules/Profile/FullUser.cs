

namespace CES.Modules.Profile.Users
{
    internal class FullUser : User
    {
        internal override string UserName
        {
            get
            {
                return m_username ?? "Not set.";
            }
            set
            {
                if (value.Length > 3)
                {
                    m_username = value;
                }
                else
                {
                    Console.WriteLine("Uncorrect Lenght");
                }
            }
        }
        internal override string Email
        {
            get
            {
                return m_email ?? "Not set.";
            }
        }
        internal override bool PasswordExists
        {
            get
            {
                return true;
            }
        }

        internal FullUser(string name, string email, string password) : base(name, email, password)
        { }
    }
}
