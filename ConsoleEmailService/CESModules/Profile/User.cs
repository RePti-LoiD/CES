

namespace CES.Modules.Profile
{
    internal abstract class User
    {
        protected string? m_username;
        protected string? m_email;
        protected string? m_password;
        public enum MemberPermission
        {
            Anonymous,
            Partial,
            FullAccess
        }

        internal abstract string UserName
        {
            get; 
            set;
        }
        internal abstract string Email
        {
            get;
        }
        internal abstract bool PasswordExists
        {
            get;
        }
        internal (string, string, bool) OutData
        {
            get { return (UserName, Email, PasswordExists); }
        }
        
        internal User(string? name, string? email, string? password) 
        {
            m_username = name;
            m_email = email;
            m_password = password;
        }
        #region GetSet(commented)

        /*
        /// <summary>
        /// Returns user name. You can change it.
        /// </summary>
        internal abstract string Username
        {
            get
            {
                return m_username;
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
        /// <summary>
        /// Returns user email if it exists. If email does not exist => Empty string.
        /// </summary>
        internal string Email
        {
            get
            {
                if (m_email != null)
                {
                    return m_email;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// Returns Boolean (True) if password exists.
        /// </summary>
        internal bool PasswordExists
        {
            get
            {
                if (m_password != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        */
        #endregion GetSet
    }
}
