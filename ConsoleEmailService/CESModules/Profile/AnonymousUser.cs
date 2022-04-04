

namespace CES.Modules.Profile.Users
{
    internal class AnonymousUser : User
    {
        internal override string UserName
        {
            get
            {
                return "Anonymous profile.";
            }
            set
            { }
        }
        internal override string Email
        {
            get
            {
                return "Anonymous profile.";
            }
        }
        internal override bool PasswordExists
        {
            get
            {
                return false;
            }
        }

        internal AnonymousUser() : base(null, null, null)
        { }
    }
}
