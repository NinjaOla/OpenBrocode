using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Authentication;
using Tweetinvi.Core.Interfaces;

namespace Twitter
{
    public class Twitter
    {
        private string userAccessToken { get; set; }
        private string userAccessTokenSecret { get; set; }

        private readonly string ConsumerKey = "GoxcBKPhOucTVyvjvPyMVE2Rf";
        private readonly string ConsumerSecret = "0yrMFJrEEzFxgAeFWdNveotAdeCEebHRiwRAF406zK8wHfnFJO";

        private ITwitterCredentials userCredentials;

        public event EventHandler loginEventHandler;

        private IAuthenticatedUser user;
        public IAuthenticatedUser User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
            }
        }


        public Twitter()
        {
            
        }

        public ITweet publishTweet(string text)
        {
            return Tweet.PublishTweet(text);
        }

        public void authenticateApp()
        {
            if(this.userCredentials == null)
            {
                // Create a new set of credentials for the application.
                var appCredentials = new TwitterCredentials(this.ConsumerKey, this.ConsumerSecret);

                // Init the authentication process and store the related `AuthenticationContext`.
                var authenticationContext = AuthFlow.InitAuthentication(appCredentials);

                // Go to the URL so that Twitter authenticates the user and gives him a PIN code.
                Process.Start(authenticationContext.AuthorizationURL);

                // Ask the user to enter the pin code given by Twitter
                Console.WriteLine("Please input the autorization pin code from Twitter:");
                var pinCode = Console.ReadLine();

                // With this pin code it is now possible to get the credentials back from Twitter
                this.userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(pinCode, authenticationContext);

                // Use the user credentials in your application
                Auth.SetCredentials(this.userCredentials);

                // Get the AuthenticatedUser from the current thread credentials
                this.User = Tweetinvi.User.GetAuthenticatedUser();

                // Stores the usercredentials for later use
                this.storeUserCredentials(this.userCredentials.AccessToken, this.userCredentials.AccessTokenSecret);

                // Gives feedback that the user is authenticated
                Console.WriteLine("Authenticated user: " + this.User);
            }
        }

        protected virtual void OnLoginCompleted(EventArgs e)
        {
            EventHandler handler = this.loginEventHandler;
            handler(this, e);
        }

        public string getUserAccessToken()
        {
            return userAccessToken;
        }

        public string getUserAccessTokenSecret()
        {
            return userAccessTokenSecret;
        }

        public string getConsumerKey()
        {
            return ConsumerKey;
        }

        public string getConsumerSecret()
        {
            return ConsumerSecret;
        }

        private void storeUserCredentials(string accessToken, string accessTokenSecret)
        {
            this.userAccessToken = accessToken;
            this.userAccessTokenSecret = accessTokenSecret;

            OnLoginCompleted(new EventArgs());
        }

        private string getAccessToken()
        {
            return this.userAccessToken;
        }

        private string getAccessTokenSecret()
        {
            return this.userAccessTokenSecret;
        }

    }
}
