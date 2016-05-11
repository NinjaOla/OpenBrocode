using FacebookSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook
{
    /// <summary>
    /// Using FacebookSharp : https://github.com/prabirshrestha/FacebookSharp
    /// </summary>
    public class OB_Facebook
    {

        public readonly FacebookSettings _fb;

        private readonly string client_id = "1745949208958643";

        private readonly string client_secret = "fc3e44196201e09b73b28d0c4c169864";

        private readonly string response_type = "token";

        private readonly string redirect_uri = "https://www.facebook.com/connect/login_success.html";

        public OB_Facebook()
        {
            this._fb = new FacebookSettings
            {
                ApplicationKey = this.client_id,
                ApplicationSecret = this.client_secret,
            };


        }


        /*private Uri login()
        {
            Dictionary<string, object> loginParameters = new Dictionary<string, object>();

            loginParameters["client_id"] = "1745949208958643";
            loginParameters["client_secret"] = "fc3e44196201e09b73b28d0c4c169864";
            loginParameters["response_type"] = "token";
            loginParameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";

            return this._fb.GetLoginUrl(loginParameters);
        }*/
    }
}
