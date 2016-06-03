using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenBrocode;
using System.Diagnostics;

namespace LayoutTest
{
    [TestClass]
    public class LayoutTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Testing not finished, got stuck on this one. 
            //Hard to unit test GUI
            WelcomeUC testUC = new WelcomeUC();
            testUC.InitializeComponent();
            //Assert.AreEqual(testUC.InitializeComponent, );
        }
    }
}
