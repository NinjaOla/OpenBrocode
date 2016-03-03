using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace UnitTestServer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            foreach(string name in resourceNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
