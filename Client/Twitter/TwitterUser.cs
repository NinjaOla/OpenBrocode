using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Authentication;
using Tweetinvi.Core.Exceptions;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models;

namespace Twitter
{
    public class TwitterUser
    {
        private IAuthenticatedUser authenticatedUser;

        public IEnumerable<ITweet> HomeTimeline
        {
            get
            {
                return authenticatedUser.GetHomeTimeline();
            }
        }

        public TwitterUser(IAuthenticatedUser authenticatedUser)
        {
            this.authenticatedUser = authenticatedUser;
        }

        public ITweet publishTweet(string text)
        {
            return Tweet.PublishTweet(text);

           /** IEnumerable<ITwitterException> latestException = ExceptionHandler.GetExceptions();

            foreach (ITwitterException exception in latestException)
            {
                System.Console.WriteLine("Exception: '{0}'", exception.ToString());
            } */

        }

        /// <summary>
        /// Butt-ugly way to do this, but it twerks.
        /// </summary>
        /// <param name="tweetText"></param>
        /// <returns></returns>
        public bool deleteTweet(string tweetText)
        {
            IEnumerable<ITweet> tweets = Tweet.GetTweets();

            foreach(ITweet tweet in tweets)
            {
                if(tweet.Text.Equals(tweetText))
                {
                    Tweet.DestroyTweet(tweet.Id);
                    return true;
                }
            }
            return false;
        }

        public bool deleteTweet(long tweetId)
        {
            Tweet.DestroyTweet(tweetId);
            return true;
        }

        public IEnumerable<ITweet> getTweets(int maxTweets)
        {
            var userTimeline = new Tweetinvi.Core.Parameters.UserTimelineParameters()
            {
                MaximumNumberOfTweetsToRetrieve = maxTweets,
                IncludeRTS = true
            };

            return Timeline.GetUserTimeline(this.authenticatedUser, userTimeline);
        }

        public IAccountSettings getAccountSettings()
        {
            return this.authenticatedUser.GetAccountSettings();
        }

        public IEnumerable<IMessage> getLatestMessageReceived()
        {
            return this.authenticatedUser.GetLatestMessagesReceived();
        }

        public IEnumerable<IMessage> getLatestMessagesSent()
        {
            return this.authenticatedUser.GetLatestMessagesSent();
        }
        
        public IRelationshipDetails getRelationshipDetailts(string screenName)
        {
            return this.authenticatedUser.GetRelationshipWith(screenName);
        }

        public IEnumerable<ISavedSearch> getSavedSearches()
        {
            return this.authenticatedUser.GetSavedSearches();
        }

        public void followUser(string screenName)
        {
            this.authenticatedUser.FollowUser(screenName);
        }

        public void unFollowUser(string screenName)
        {
            this.authenticatedUser.UnFollowUser(screenName);
        }

        public void blockUser(string userName)
        {
            this.authenticatedUser.BlockUser(userName);
        }

        public void unBlockUser(string userName)
        {
            this.authenticatedUser.UnBlockUser(userName);
        }


    }
}
