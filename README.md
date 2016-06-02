# Social Awareness System

The Social Awareness System(SAS) is an Open-Source based project made by a group of students attending an Open-Source class at the University of Agder, Norway. 
In it's essence, SAS is a collection of different social media accounts braided into a simple GUI where the user can have control of his social media accounts,
in stead of keeping control of many tabs in the web browser. 

The idea of Open-Sourcing it was in our opinion the best alternative here, as we now have provided a shell with some functionality, where other contributors
are free to continue working on the project by adding other API's and integrating it. The ultimate goal is to have it so well functioning that 
new contributors can just add their API of choice and then be able to toggle which should be active from the settings menu.

# Code example

Here we will add an example of how we manipulate the API's to gain the information we are after. For example, we have managed to both send a Tweet on Twitter from our GUI,
as well as retrieve the Tweets from the timeline and view different fields from the Tweets (Author, text, date for example).

'''
        public IEnumerable<ITweet> getTweets(int maxTweets)
        {
            var userTimeline = new Tweetinvi.Core.Parameters.UserTimelineParameters()
            {
                MaximumNumberOfTweetsToRetrieve = maxTweets,
                IncludeRTS = true
            };

            return Timeline.GetUserTimeline(this.authenticatedUser, userTimeline);
        }
'''

# Motivation

Our motivation to start this project is that we brainstormed ideas and landed on this due to the need we feel oruselves to a project like this,
as well as we felt it would be interesting to learn about manipulating different API's as this is important within the Open-Source community.
We conducted an online survey where the replies(around 250 replies in total) indicated that we were on to something. 99,1% of the replicants stated that they used their social media accounts several times a day,
and almost 50% had 2-4 open tabs of social media at once. 

# Installation

# API Reference

# Tests

# Contributors

# License
