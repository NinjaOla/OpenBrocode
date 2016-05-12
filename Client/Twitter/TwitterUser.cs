using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Authentication;
using Tweetinvi.Core.Interfaces;
using Tweetinvi.Core.Interfaces.Models;

namespace Twitter
{
    public class TwitterUser
    {
        // Get the AuthenticatedUser from the current thread credentials
        private IAuthenticatedUser authenticatedUser;
        private IEnumerable<ITweet> homeTimeline;
        private IAccountSettings accountSettings;
        private IEnumerable<IMessage> latestMessagesReceived;
        private IEnumerable<IMessage> latestMessagesSent;
        private IRelationshipDetails relationshipDetails;
        private IEnumerable<ISavedSearch> savedSearches;

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

        public IAccountSettings getAccountSettings()
        {
            return authenticatedUser.GetAccountSettings();
        }

        public void getLatestMessageReceived()
        {
            this.latestMessagesReceived = authenticatedUser.GetLatestMessagesReceived();
        }

        public void getLatestMessagesSent()
        {
            this.latestMessagesSent = authenticatedUser.GetLatestMessagesSent();
        }
        
        public void getRelationshipDetailts(string screenName)
        {
            this.relationshipDetails = authenticatedUser.GetRelationshipWith(screenName);
        }

        public void getSavedSearches()
        {
            this.savedSearches = authenticatedUser.GetSavedSearches();
        }

        public void followUser(string screenName)
        {
            authenticatedUser.FollowUser(screenName);
        }

        public void unFollowUser(string screenName)
        {
            authenticatedUser.UnFollowUser(screenName);
        }

        public void blockUser(string userName)
        {
            authenticatedUser.BlockUser(userName);
        }

        public void unBlockUser(string userName)
        {
            authenticatedUser.UnBlockUser(userName);
        }


    }
}
