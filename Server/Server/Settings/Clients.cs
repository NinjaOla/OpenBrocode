using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Settings
{

    // https://www.scottbrady91.com/Identity-Server/Identity-Server-3-Standalone-Implementation-Part-1
    class Clients
    {
        public static IEnumerable<Client> Get() {
            return new List<Client> {
                new Client {
                    ClientId = "1234", 
                    ClientName = "Example implicit client", 
                    Enabled = true, 
                    Flow = Flows.Implicit, 
                    RequireConsent = true, 
                    AllowRememberConsent = true, 
                    RedirectUris = new List<string>(), 
                    AllowedScopes = new List<string> {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email
                    },
                    AccessTokenType = AccessTokenType.Jwt 
                }
            };

        }
    }
}
