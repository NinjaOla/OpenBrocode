using OpenBrocode.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrocode.User
{
    class LoginHandler
    {
        private Dictionary<String, String> users = new Dictionary<string,string>()
        {
            {"Robin", ""} , 
            {"John", ""}, 
            {"Daniel", ""}, 
            {"Bob", ""}
        };

        private static UserObject user; 

        public LoginHandler()
        {

        }

        public bool login(string username, string password)
        {
            if(this.users.ContainsKey(username))
            {
                if (this.users[username].Equals(password))
                    return true; 
            }
            return false; 

        }

        public void setLoggedInUser(string userName, string password)
        {
            if(LoginHandler.user != null)
                throw new UserLoggedInException();

            LoginHandler.user = new UserObject
            {
                UserName = userName,
                Password = password,
                settings = new Settings()
            };
        }

        public static bool logOut()
        {
            LoginHandler.user = null;
            return true; 
        }

        public static void isUserLoggedIn()
        {

        }
    }
}
