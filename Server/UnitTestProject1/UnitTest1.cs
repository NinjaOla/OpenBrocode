using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            
            Console.WriteLine("Test"); 
            
            foreach (string name in resourceNames)
                        {
                            Console.WriteLine(name);
                        }
                    }
    }
}
