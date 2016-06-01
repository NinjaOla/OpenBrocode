using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Functionality.Exceptions
{
    public class FacebookSettingsException : Exception
    {
        public FacebookSettingsException() : base("Facebook settings exception")
        {

        }

        public FacebookSettingsException(string message) : base(message)
        {

        }

        public FacebookSettingsException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
