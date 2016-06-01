using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.OB.Facebook.Parameters
{
    /// <summary>
    /// https://developers.facebook.com/docs/facebook-login/manually-build-a-login-flow
    /// </summary>
    public static class ResponseType
    {

        /// <summary>
        /// Response data is included as URL parameters and contains code parameter (an encrypted string unique to each login request). This is the default behaviour if this parameter is not specified. It's most useful when your server will be handling the token.
        /// </summary>
        public const string code = "code";

        /// <summary>
        /// Response data is included as a URL fragment and contains an access token. Desktop apps must use this setting for response_type. This is most useful when the client will be handling the token.
        /// </summary>
        public const string token = "token";

        /// <summary>
        /// Response data is included as a URL fragment and contains an access token. Desktop apps must use this setting for response_type. This is most useful when the client will be handling the token.
        /// </summary>
        public const string code_token = code + "%20" + token;

        /// <summary>
        /// Response data is included as a URL fragment and contains both an access token and the code parameter.
        /// </summary>
        public const string granted_scopes = "granted_scopes";

    }
}
