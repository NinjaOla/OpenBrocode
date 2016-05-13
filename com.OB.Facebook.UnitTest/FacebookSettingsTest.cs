using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace com.OB.Facebook.UnitTest
{
    [TestClass]
    public class FacebookSettingsTest
    {

        private FacebookSettings settings; 

        [TestInitialize]
        public void TestInitialize()
        {
            settings = new FacebookSettings(); 
        }


        [TestMethod]
        public void testSettingUri()
        {
            settings.RedirectUri = "https://www.facebook.com/dialog/oauth?";

            Assert.IsNotNull(settings.RedirectUri); 
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void testSettingsUriException()
        {
            settings.RedirectUri = "NotAUrl"; 
        }
    }
}
