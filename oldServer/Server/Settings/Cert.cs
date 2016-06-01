using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Server.Settings
{
    class Cert
    {
        private static String resourcePath = "Server.Resources.idsrv3test.pfx";
        //private static sealed String resourcePath = "Server.Settings.idsrv3test.pfx"; 


        public static X509Certificate2 Load()
        {
            var assembly = typeof(Cert).Assembly;

            using (var stream = assembly.GetManifestResourceStream(resourcePath))
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }

            /*
            using (var stream = assembly.GetManifestResourceStream(@"C:\Users\John-Martin\Documents\GitHub\OpenBrocode\Server\Server\Resources\idsrv3test.pfx"))
            {
                return new X509Certificate2(ReadStream(stream), "idsrv3test");
            }*/

        }

        public static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
