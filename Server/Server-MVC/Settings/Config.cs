using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server_MVC
{
    public class Config
    {
        public static readonly string host = "https://localhost:44302/";

        public static readonly string authorityLink = host + "identity";

        public static readonly string clientId = "mvc"; 

    }
}