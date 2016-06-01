using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Functionality.Exceptions
{
    public class FacebookException : Exception
    {
        public FacebookException() : base("Facebook Excetpion")
        {

        }

        public FacebookException(string message) : base(message)
        {

        }

        public FacebookException(string message, Exception ex) : base(message, ex)
        {

        }
    }

}
