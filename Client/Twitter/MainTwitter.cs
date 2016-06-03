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
    public class MainTwitter
    {
        private string userAccessToken { get; set; }
        private string userAccessTokenSecret { get; set; }

        private readonly string ConsumerKey = "GoxcBKPhOucTVyvjvPyMVE2Rf";
        private readonly string ConsumerSecret = "0yrMFJrEEzFxgAeFWdNveotAdeCEebHRiwRAF406zK8wHfnFJO";
        private IAuthenticationContext authenticationContext;



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

        public TwitterUser twitterUser;

        public MainTwitter()
        {

        }

        public bool userLoggedIn()
        {
            if(this.user != null)
            {
                return true;
            }

            return false;
        }

        public bool authenticateUser(string userAccessToken, string userAccessTokenSecret)
        {
            if (this.userCredentials == null)
            {
                var userCredentials = new TwitterCredentials(this.ConsumerKey, this.ConsumerSecret, userAccessToken, userAccessTokenSecret);
                this.User = Tweetinvi.User.GetAuthenticatedUser(userCredentials);

                if(this.user != null)
                {
                    storeUserCredentials(userCredentials.AccessToken, userCredentials.AccessTokenSecret);
                    this.twitterUser = new TwitterUser(this.user);

                    return true;
                }
            }
            else
                throw new Exception("User credensials cannot be null");

            return false;
        }

        //Will run in GUI, waits for input.
        public void authenticateUser(string pin)
        {
            // With this pin code it is now possible to get the credentials back from Twitter
            this.userCredentials = AuthFlow.CreateCredentialsFromVerifierCode(pin, authenticationContext);

            // Use the user credentials in your application
            Auth.SetCredentials(this.userCredentials);

            // Get the AuthenticatedUser from the current thread credentials
            this.User = Tweetinvi.User.GetAuthenticatedUser();

            // Stores the usercredentials for later use
            this.storeUserCredentials(this.userCredentials.AccessToken, this.userCredentials.AccessTokenSecret);

            this.twitterUser = new TwitterUser(this.user);
        }

        public void authenticateApp()
        {
            if(this.userCredentials == null)
            {
                // Create a new set of credentials for the application.
                var appCredentials = new TwitterCredentials(this.ConsumerKey, this.ConsumerSecret);

                // Init the authentication process and store the related `AuthenticationContext`.
                this.authenticationContext = AuthFlow.InitAuthentication(appCredentials);

                // Go to the URL so that Twitter authenticates the user and gives him a PIN code.
                Process.Start(authenticationContext.AuthorizationURL);
            }
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
        }




    }
}
