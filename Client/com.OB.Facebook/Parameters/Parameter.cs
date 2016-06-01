using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Parameters
{
    /// <summary>
    /// A collection class of all the valid string paramters that is possible to send to the link. 
    /// </summary>
    internal class Parameter
    {
        public static readonly string ClientId = "client_id";

        public static readonly string RedirectUri = "redirect_uri";
         
        public static readonly string State = "state";

        public static readonly string Response_Type = "response_type";

        public static readonly string Scope = "scope"; 

    }
}
