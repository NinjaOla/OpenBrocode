using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Exceptions;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models;

namespace Twitter.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Twitter twitter = new Twitter();
            twitter.loginEventHandler += new EventHandler(loginEvent);
            twitter.authenticateApp();

            

            System.Console.ReadLine();
        }

        public static void loginEvent(object sender, System.EventArgs e)
        {
            Twitter twitter = (Twitter)sender;
            Auth.SetUserCredentials(twitter.getConsumerKey(), twitter.getConsumerSecret(), twitter.getUserAccessToken(), twitter.getUserAccessTokenSecret());
            System.Console.WriteLine("Login works");
            publishTweetTimeLine(twitter);
        }

        public static void publishTweetTimeLine(Twitter twitter)
        {
            TwitterUser twitterUser = new TwitterUser(twitter.User);
            //ITweet tweetz = twitter.publishTweet("I love Tweetinvi");
            IEnumerable<ITwitterException> latestException = ExceptionHandler.GetExceptions();

            foreach(ITwitterException exception in latestException)
            {
                System.Console.WriteLine("Exception: '{0}'", exception.ToString());
            }

            //System.Console.WriteLine("The following error occured : '{0}'", latestException.TwitterDescription);

            foreach (ITweet tweet in twitterUser.HomeTimeline)
            {
                System.Console.WriteLine(tweet.Text);
                System.Console.WriteLine(tweet.CreatedBy);
            }
        }
    }
}
