using IdentityServer3.Core.Configuration;
using Owin;
using Server.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
    internal class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            IdentityServerServiceFactory factory = new IdentityServerServiceFactory();

            factory
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryClients(Scopes.get())
                    .UseInMemoryClients(Users.get());
        }
    }
}
