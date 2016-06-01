using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server_MVC
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client 
                {
                    Enabled = true,
                    ClientName = "MVC Client",
                    ClientId = Config.clientId,
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        Config.host 
                    },
                
                    AllowAccessToAllScopes = true
                }
            };
        }
    }
}