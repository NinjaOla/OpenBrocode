using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace com.OB.Facebook
{

    /// <summary>
    /// Using FacebookSharp : https://github.com/prabirshrestha/FacebookSharp
    /// </summary>
    public class MainFacebook
    {


        private readonly string client_id = "284489194896438";

        private readonly string client_secret = "fc3e44196201e09b73b28d0c4c169864";

        private readonly string response_type = "token";

        private readonly string redirect_uri = "https://www.facebook.com/connect/login_success.html";

        private Uri _loginUri; 


        public MainFacebook()
        {

            VersionManager manager = new VersionManager(); 

            FacebookSettings settings = new FacebookSettings
            {
                ClientId = this.client_id,
                RedirectUri = this.redirect_uri, 
                Scope = new com.OB.Facebook.Parameters.Scope
                {
                    Premissions = com.OB.Facebook.Parameters.Premissions.PremissionList.getAllRigts() 
                }
            };


            //Console.WriteLine(settings.getConnectionUrl());
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
