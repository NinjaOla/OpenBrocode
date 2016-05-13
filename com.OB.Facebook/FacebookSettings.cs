using com.OB.Facebook.Exceptions;
using com.OB.Facebook.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.OB.Facebook.Parameters; 

namespace com.OB.Facebook
{
    public class FacebookSettings
    {

        public string ClientId { get; set; }


        private string redirectUri = null;

        /// <summary>
        /// Set a redirect uri that the facebook application is supposed to redirect to after login is finished. 
        /// Throws a exception if it is not a absolute url. 
        /// </summary>
        public string RedirectUri
        {
            get
            {
                if (this.redirectUri == null)
                    return "https://www.facebook.com/connect/login_success.html"; 
                else
                    return this.redirectUri; 
            }
            set
            {
                if(!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    throw new Exception("The string is not a url");
                }

                this.redirectUri = value; 
            }
        }

        public string State { get; set; }

        public com.OB.Facebook.Parameters.Scope Scope { get; set; }


        private string responseType = null;

        /// <summary>
        /// Set a response type 
        /// Look a com.OB.Facebook.Paramters.ResonseType for valid responses. 
        /// </summary>
        public string ResponseType
        {
            get
            {
                return this.responseType; 
            }
            set
            {
                switch(value)
                {
                    case com.OB.Facebook.Parameters.ResponseType.code:
                        this.responseType = value;
                        break;
                    case com.OB.Facebook.Parameters.ResponseType.code_token:
                        this.responseType = value;
                        break; 
                    case com.OB.Facebook.Parameters.ResponseType.granted_scopes:
                        this.responseType = value;
                        break; 
                    case com.OB.Facebook.Parameters.ResponseType.token:
                        this.responseType = value;
                        break; 
                    default:
                        throw new Exception("Not a valid response type"); 
                }
                this.responseType = null; 
            }
        }

        private string facebookUrl = "https://www.facebook.com/dialog/oauth?";

        public FacebookSettings()
        {

        }

        public FacebookSettings(FacebookSettings settings)
        {
            if (settings == null)
                throw new FacebookSettingsException("Settings cannot be null");

            this.ClientId = settings.ClientId;

            this.RedirectUri = settings.RedirectUri;

            this.State = settings.State; 

            this.Scope = settings.Scope; 
        }

        public string getConnectionUrl()
        {
            string temp = "";

    
            if(this.ClientId != null)
            {
                temp += Parameter.ClientId + "=" + this.ClientId + "&"; 
            }

            if(this.RedirectUri != null)
            {
                temp += Parameter.RedirectUri + "=" + this.RedirectUri + "&"; 
            }

            if(this.State != null)
            {
                temp += Parameter.State + "=" + this.State + "&"; 
            }

            if(this.ResponseType != null)
            {
                temp += Parameter.Response_Type + "=" + this.ResponseType + "&"; 
            }
            
            if(this.Scope != null)
            {
                temp += Scope.ToString() + "=" + this.Scope.getRights() + "&"; 
            }


            temp = temp.TrimEnd('&'); 

            return this.facebookUrl + temp; 
        }
    }
}
