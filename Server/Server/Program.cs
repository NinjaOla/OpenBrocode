using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            Console.WriteLine("Test");

            foreach (string name in resourceNames)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine(); 
        }
    }
}
