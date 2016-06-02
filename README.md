# Social Awareness System

The Social Awareness System(SAS) is an Open-Source based project made by a group of students attending an Open-Source class at the University of Agder, Norway. 
In it's essence, SAS is a collection of different social media accounts braided into a simple GUI where the user can have control of his social media accounts,
in stead of keeping control of many tabs in the web browser. 

The idea of Open-Sourcing it was in our opinion the best alternative here, as we now have provided a shell with some functionality, where other contributors
are free to continue working on the project by adding other API's and integrating it. The ultimate goal is to have it so well functioning that 
new contributors can just add their API of choice and then be able to toggle which should be active from the settings menu.

# Walkthrough example of the functionality

Here is an example of how the program connects to twitter and allows you to post a tweet and watch the tweets in your timeline:
[Walkthrough](https://github.com/Nyranith/OpenBrocode/blob/master/SAS%20twitter%20guide.pdf)


# Code example

Here we will add an example of how we manipulate the API's to gain the information we are after. For example, we have managed to both send a Tweet on Twitter from our GUI,
as well as retrieve the Tweets from the timeline and view different fields from the Tweets (Author, text, date for example).


* Here is an example of how we retrieve the tweets of a user:
```
        public IEnumerable<ITweet> getTweets(int maxTweets)
        {
            var userTimeline = new Tweetinvi.Core.Parameters.UserTimelineParameters()
            {
                MaximumNumberOfTweetsToRetrieve = maxTweets,
                IncludeRTS = true
            };

            return Timeline.GetUserTimeline(this.authenticatedUser, userTimeline);
        }
```

* Here is an example of how we user authentication:
```
        public void loginEventHandler(object sender, EventArgs e)
        {
            MainTwitter twitter = (MainTwitter)sender;

            UserHandler.getUser().settings.settings.TwitterUserToken = twitter.getUserAccessToken();

            UserHandler.getUser().settings.settings.TwitterUserSecretToken = twitter.getUserAccessTokenSecret();

            UserHandler.getUser().settings.writeFile(); 
        }
```


# Motivation

Our motivation to start this project is that we brainstormed ideas and landed on this due to the need we feel oruselves to a project like this,
as well as we felt it would be interesting to learn about manipulating different API's as this is important within the Open-Source community.
We conducted an online survey where the replies(around 250 replies in total) indicated that we were on to something. 99,1% of the replicants stated that they used their social media accounts several times a day,
and almost 50% had 2-4 open tabs of social media at once. 

# Installation

As this project is not yet finished, an installation wizard has not yet been created. It is, however, rather simple to get it running to try it out.

1. Clone the repository
2. Open it in Visual Studio 2013 or newer (This is written in C#/.Net and is therefore reccommended to be run in Visual Studio)
3. Open OpenBrocode.sln from the Client folder. 
4. Clean, build and start the project

# API Reference

# Tests

# Contributors

To be able to contribute here, you have to either create an issue for us to look at and review or create a pull request if you have something to add or if you have fixed something yourself. Remember to always comment and describe what you contribute to make it easier for others to review and possibly use the contribution. 

We accept all contributors and no question or remark is unwanted. 

# License

(GNU GPL v3)

Read LICENSE
