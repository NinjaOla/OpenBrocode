using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;

namespace ClientTest
{
    class ClientToken
    {
        public static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "openBrocode",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8"
            );

            return client.RequestClientCredentialsAsync("api1").Result; 
        }

        public static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);

            Console.WriteLine(client.GetStreamAsync("http://localhost:14869/test").Result);
        }
    }
}
