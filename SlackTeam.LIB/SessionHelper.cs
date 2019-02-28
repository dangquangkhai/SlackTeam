using SlackTeam.LIB.Model;
using SlackTeam.LIB.Provider;
using System.Web;

namespace SlackTeam.LIB
{
    public class SessionHelper
    {
        protected static User _CurrentUser = new User();
        public static User CurrentUser 
        {
            get {
                string Email = HttpContext.Current.User.Identity.Name;
                if (string.IsNullOrEmpty(Email))
                {
                    User anonymousUser = new User();
                    anonymousUser.ID = -1;
                    anonymousUser.Firstname = "Vô";
                    anonymousUser.Lastname = "Danh";
                    return anonymousUser;
                }
                 UserProvider user = new UserProvider();

                return user.getUserByEmail(Email);
            }
            set {
                _CurrentUser = value;
            }
        }
    }
}
