using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mail;

namespace mailTests
{
    [TestClass]
    public class verifyMailTest
    {
        private mailSender newMailSender = null;
        private String mailAddress = null;
        private String mailPassword = null;

        [TestInitialize]
        public void main()
        {
            this.mailAddress = "openbrocode@gmail.com";
            this.mailPassword = "brocode1337";

            this.newMailSender = new mailSender(this.mailAddress, this.mailPassword);

            this.newMailSender.logIn();
        }
        

        [TestMethod]
        public void testLoginMethod()
        {
            
            this.newMailSender.logIn();

            Console.WriteLine("Logged in");

           // newMailSender.logOut();

            Console.WriteLine("Logged out");
        }

        

        [TestMethod]
        public void mailIsConnected()
        {
            //arrange
            

            var expected = true;

            var actual = Convert.ToString(this.newMailSender.getIsConnected());

            //act
            this.newMailSender.connect();

            //assert
            Assert.IsTrue(expected, actual);

            
        }

        [TestMethod]
        public void mailMessageSent()
        {

            //arrange
           
            String from = mailAddress;
            String to = "thomasorsnes@gmail.com";
            String subject = "Håper dette funker";
            String body = "Hei gamle ørn, lenge siden sist!";

            //act
            
            this.newMailSender.newMailMessage(from, to, subject, body);

            //assert

        }

        [TestMethod]
        public void testGetUnseenMessages()
        {
            String mailAddress = "openbrocode@gmail.com";
            String mailPassword = "brocode1337";

            mailSender newMailSender = new mailSender(mailAddress, mailPassword);

            newMailSender.retrieveUnseenMessages();

            
        }

        [TestMethod]
        public void testLogoutMethod()
        {

            this.newMailSender.logOut();


            var expected = false;

            var actual = Convert.ToString(this.newMailSender.getIsConnected());

            Assert.IsTrue(expected, actual);

        }
    }
}
