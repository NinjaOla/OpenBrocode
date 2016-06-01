using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Configuration; 
using Server.Settings;
using Server.Authentication;
using Server;
using Microsoft.Owin;
using Serilog;
using SerilogWeb.Classic.Enrichers;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using IdentityServer3.Core.Services;
using IdentityServer3.AspNetIdentity; 

[assembly: OwinStartup("InMemory", typeof(Startup))]

namespace Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/core",
                coreApp =>
                {
                    var factory =
                        new IdentityServerServiceFactory()
                        .UseInMemoryClients(Clients.Get())
                        .UseInMemoryScopes(Scopes.Get());

                    factory.Register(new Registration<IdentityDbContext>());
                    factory.Register(new Registration<UserStore<IdentityUser>>());
                    factory.Register(new Registration<UserManager<IdentityUser, string>>
                        (x => new UserManager<IdentityUser>(x.Resolve<UserStore<IdentityUser>>())));

                    factory.UserService = new Registration<IUserService, AspNetIdentityUserService<IdentityUser, string>>();


                    coreApp.UseIdentityServer(new IdentityServerOptions
                    {
                        SiteName = "Standalone Identity Server", 
                        SigningCertificate = Cert.Load(),
                        Factory = factory,
                        RequireSsl = true 
                    }); 
                });

           

        }
       
    }
}