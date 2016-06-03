using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrocode.User
{
    class UserObject
    {
        public string UserName { get; set; }

        private string password;

        public string Password
        {
            set
            {
                this.password = value; 
            }
            get
            {
                return this.password; 
            }
        }

        public Settings settings { get; set; }

        public UserObject()
        {

        }

        public UserObject(UserObject userObject)
        {
            this.UserName = userObject.UserName;

            this.Password = userObject.Password;

            this.settings = userObject.settings; 
        }
    }
}
