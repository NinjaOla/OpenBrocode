using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Exceptions;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models;
using Twitter;

namespace TwitterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainTwitter twitter = new MainTwitter();
            twitter.loginEventHandler += new EventHandler(loginEvent);
            twitter.authenticateApp();

            /**List<ITweet> userTimeline = twitter.twitterUser.HomeTimeline.ToList();
            foreach(ITweet tweet in userTimeline)
            {
                if(tweet.Text.Equals("something"))
                {
                    twitter.twitterUser.deleteTweet(tweet.Id);
                }
            } */

            System.Console.WriteLine("Input your tweet: ");
            twitter.User.PublishTweet(System.Console.ReadLine());
            System.Console.ReadLine();
        }

        public static void loginEvent(object sender, System.EventArgs e)
        {
            MainTwitter twitter = (MainTwitter)sender;
            Auth.SetUserCredentials(twitter.getConsumerKey(), twitter.getConsumerSecret(), twitter.getUserAccessToken(), twitter.getUserAccessTokenSecret());
            System.Console.WriteLine("Login works");
        }

        public static void getUserHomeTimeline(MainTwitter twitter)
        {
            foreach (ITweet tweet in twitter.twitterUser.HomeTimeline)
            {
                System.Console.WriteLine(tweet.Text);
                System.Console.WriteLine(tweet.CreatedBy);
            }
        }
    }
}
