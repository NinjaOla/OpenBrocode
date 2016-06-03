using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBrocode.Exceptions
{
    class UserLoggedInException : Exception
    {
        public UserLoggedInException() : base("User is logged in")
        {

        }

        public UserLoggedInException(string message) : base(message)
        {

        }

        public UserLoggedInException(string message, Exception e) : base(message, e)
        {

        }
    }
}
