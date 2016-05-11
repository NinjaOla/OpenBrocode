using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Authentication
{
    internal static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser> {
            new InMemoryUser {
                Subject = "1",
                Username = "John Dahl",
                Password = "Password123!",
                Claims = new List<Claim> {
                    new Claim(Constants.ClaimTypes.GivenName, "John"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Dahl"),
                    new Claim(Constants.ClaimTypes.Email, "kaalsaas@hotmail.com")
                    }
                }
            };
        }
    }
}
