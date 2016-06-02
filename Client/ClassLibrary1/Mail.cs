using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Mail;
using S22.Imap;




namespace Mail
{
    public class mailSender
    {

        public IEnumerable<MailMessage> messages;

        public mailSender(string mail, string password)
        {
            mailAddress = mail;
            mailPassword = password;
            
        }

        private ImapClient Client = null;

        private string mailAddress = null;
        private string mailPassword = null;
        Boolean isConnected = false;

        //Starts a session with the authenticated user credentials
        public void logIn()
        {
            this.Client = new ImapClient("imap.gmail.com", 993, true);

            try
            {
                this.Client.Login(mailAddress, mailPassword, AuthMethod.Auto);
            }
            catch(InvalidCredentialsException)
            {
                Console.WriteLine("The server rejected the supplied credentials");
            }

            isConnected = true;
            //this.Client.Dispose();

        }

        //Ends a started session
        public void logOut()
        {
            this.Client.Logout();
            isConnected = false;
        }



        //autentiseringsmetode som sjekker om mailaddresse og mailpassord
        //satt inn ved ny instance av objected mailSender er valid og kan brukes
        //til å sende og motta e-post
        public bool connect()
        {
            if (mailAddress == null)
            {
                throw new Exception("Mail address is not set");
            }
            if (this.mailPassword == null)
                throw new Exception("Password is not set");

            //setter host til gmail som default
            //dette kan endres til å følge etter hvilken
            //e-post addresse brukeren har logget inn med, men det
            //krever mye arbeid
            string hostname = "imap.gmail.com",

                //her settes imap-innloggingen til mailaddressen og 
                //mailpassordet som ble brukt ved første autentisering.

               username = mailAddress, password = mailPassword;

            // The default port for IMAP over SSL is 993.
            using (ImapClient client = new ImapClient(hostname, 993, username, password, AuthMethod.Login, true))
            {
                Console.WriteLine("Connected");

                return isConnected = true;


            }
        }

        //get-metode brukt for unit testing
        public bool getIsConnected()
        {
            return isConnected;
        }



        //Her settes verdiene som inngår i en ny utgående e-post til null
        String from = null;
        String to = null;
        String subject = null;
        String body = null;

        //Default innstillinger for gmail smtp tilkobling
        String smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;
        

         //Metoden sender ny mail fra den innloggede mailaddressen, og tar parameterne
         //from(automatisk satt til mailen som er logget inn)
         //to(velges ved input av bruker)
         //subject(velges ved input av bruker)
         //body(velges ved input av bruker)
       public void newMailMessage(string from, string to, string subject, string body)
       {

            this.from = mailAddress;
            this.to = to;
            this.subject = subject;
            this.body = body;


           MailMessage newMail = new MailMessage(from, to, subject, body);
           if (this.mailAddress == null)
               throw new Exception("Mail address is not set");
            if (this.mailPassword == null)
                throw new Exception("Password is not set");

            SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);
            smtp.Credentials = new NetworkCredential(mailAddress, mailPassword);
            smtp.EnableSsl = enableSSL;
            smtp.Send(newMail); 

        }
        
        public String getMailAddress()
        {
            return mailAddress;
        }

        //Denne metoden henter uleste e-post fra inboxen
        public void retrieveUnseenMessages()
        {
            using (ImapClient Client = new ImapClient("imap.gmail.com", 993, mailAddress, mailPassword, AuthMethod.Login, true))
            {

                IEnumerable<uint> uids = Client.Search(SearchCondition.Seen());

                this.messages = Client.GetMessages(uids,false);

                
            }
        }
        [STAThread]
        static void Main()
        {
        }                                                           
    }
}
