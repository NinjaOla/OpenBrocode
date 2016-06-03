using OpenBrocode.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter;
using Mail;

namespace OpenBrocode.User
{
    class UserHandler
    {
        private Dictionary<String, String> users = new Dictionary<string,string>()
        {
            {"Robin", ""} , 
            {"John", ""}, 
            {"Daniel", "1234"}, 
            {"Bob", ""}
        };

        public static MainTwitter Twitter {get; set; }

        private static UserObject user; 

        public static mailSender Mail { get; set; }

        public UserHandler()
        {

        }

        public bool login(string username, string password)
        {
            if(this.users.ContainsKey(username))
            {
                if (this.users[username].Equals(password))
                {
                    setLoggedInUser(username, password);
                    return true; 
                }
            }
            return false; 

        }

        public void setLoggedInUser(string userName, string password)
        {
            if(UserHandler.user != null)
                throw new UserLoggedInException();

            UserHandler.user = new UserObject
            {
                UserName = userName,
                Password = password,
                settings = new Settings()
            };

            if(user.settings.settings.TwitterUserToken != null && user.settings.settings.TwitterUserSecretToken != null)
            {
                Twitter = new MainTwitter();
                if(Twitter.authenticateUser(user.settings.settings.TwitterUserToken, user.settings.settings.TwitterUserSecretToken))
                {
                   // return;
                }
            }

            if(user.settings.settings.MailUN != null && user.settings.settings.MailPW != null)
            {
                Mail = new mailSender(user.settings.settings.MailUN, user.settings.settings.MailPW);

            }

        }


        public static void mailHandler(string username, string password)
        {
            Mail = new mailSender(username, password);
            user.settings.settings.MailUN = username;
            user.settings.settings.MailPW = password;
            user.settings.writeFile();
        }



        public static bool logOut()
        {
            UserHandler.user = null;
            return true; 
        }

        public static bool isUserLoggedIn()
        {
            if (UserHandler.user != null)
                return true;

            return false; 
        }

        public static UserObject  getUser()
        {
            return UserHandler.user; 
        }

    }
}
