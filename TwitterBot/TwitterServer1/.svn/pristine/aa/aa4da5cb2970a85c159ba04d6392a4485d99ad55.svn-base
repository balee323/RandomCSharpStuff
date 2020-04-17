using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows;
using TweetSharp;
//using Tweetinvi;
//using LinqTwitter = LinqToTwitter;



namespace TwitterServerCsharp
{
    class TweetSharpService
    {

        private string DMUser = "";

        // private string consumerKey = ConfigurationSettings.AppSettings["ConsumerKey"];  //Obsolete method, replaced by ConfigurationManager
        private string consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
        private string ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
        private string AccessToken = ConfigurationManager.AppSettings["AccessToken"];
        private string AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];


        public string DirectMessageUser
        {
            get {
                return DMUser;}
            //set {
              //  DMUser = DirectMessageUser; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="TwitterUser"></param>
        /// <returns></returns>
        public List<string> getUserTweets(string TwitterUser)
        {
            var service = new TwitterService(consumerKey, ConsumerSecret);
            service.AuthenticateWith(AccessToken, AccessTokenSecret);

            ListTweetsOnUserTimelineOptions userOptions = new ListTweetsOnUserTimelineOptions();

          //  userOptions.ScreenName = "realDonaldTrump";
            userOptions.ScreenName = TwitterUser;
            userOptions.Count = 1;
            userOptions.SinceId = 10;
            userOptions.IncludeRts = true;
      
            List<string> tweets = new List<string>();
            System.Collections.Generic.IEnumerable<TwitterStatus> tStatus;
            tStatus = service.ListTweetsOnUserTimeline(userOptions);

            if (tStatus != null)
            {
                int i = 0;
                while (i < tStatus.Count<TwitterStatus>())
                {
                    tweets.Add(tStatus.ElementAt<TwitterStatus>(i).Text);
                    tweets.Add(tStatus.ElementAt<TwitterStatus>(i).CreatedDate.ToString());
                    tweets.Add(tStatus.ElementAt<TwitterStatus>(i).Source.ToString());
                    tweets.Add("==============================");
                    i = i + 1;
                }                   
            }
            else
            {
                tweets.Add("No tweets found for User or user does not exist.");
            }
  
            // return var;
            return tweets;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void sendTweet(string message)
        {
            var service = new TwitterService(consumerKey, ConsumerSecret);
            service.AuthenticateWith(AccessToken, AccessTokenSecret);

            // Sending tweet works(sending as Brienzherelee)
            SendTweetOptions tweet = new SendTweetOptions();
            tweet.Status = message;
            var twitterStatus = service.SendTweet(tweet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="TwitterUser"></param>
        /// <param name="message"></param>
        public void sendDirectMessage(string TwitterUser, string message)
        {
            var service = new TwitterService(consumerKey, ConsumerSecret);
            service.AuthenticateWith(AccessToken, AccessTokenSecret);
     
            SendDirectMessageOptions msgOpt = new SendDirectMessageOptions();
            msgOpt.ScreenName = "@" + TwitterUser;
            msgOpt.Text = message;
            service.SendDirectMessage(msgOpt);
        }

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void ReplyDirectMessage(string message)
        {
            sendDirectMessage(DMUser, message);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDirectMessage()
        {
            string directMessage = "";


            //Using TweetSharp------------------------------------------------------------------------------------------
            // ===========================================
            var service = new TwitterService();
            // service.AuthenticateWith(AccessToken, AccessTokenSecret);
            service.AuthenticateWith(consumerKey, ConsumerSecret, AccessToken, AccessTokenSecret);
            
            var message = new TweetSharp.TwitterDirectMessage();
            message.RecipientScreenName = "BrienzhereLee";  

            GetDirectMessageOptions getDMoptions = new GetDirectMessageOptions();
                     
            ListDirectMessagesReceivedOptions lstDMoptions = new ListDirectMessagesReceivedOptions();
            lstDMoptions.Count = 5;
            lstDMoptions.SinceId = 1000;


            service.BeginGetDirectMessage(getDMoptions);
            //service.BeginListDirectMessagesReceived(lstDMoptions);
           var DirectMessagesRaW = service.ListDirectMessagesReceived(lstDMoptions);         //returns null!!!


            if (DirectMessagesRaW != null)
            {
                int i = 0;
                while (i < DirectMessagesRaW.Count<TwitterDirectMessage>())
                {
                    directMessage = (DirectMessagesRaW.ElementAt<TwitterDirectMessage>(i).Text);
                    DMUser = (DirectMessagesRaW.ElementAt<TwitterDirectMessage>(i).SenderScreenName);
                    i = i + 1;
                }
            }
            else
            {
                directMessage = (".");
            }
            //===========================================

            //===========================================
            //var service = new TwitterService(consumerKey, ConsumerSecret);
            //service.AuthenticateWith(AccessToken, AccessTokenSecret);
            //GetDirectMessageOptions dmOp = new GetDirectMessageOptions();

            //TwitterDirectMessage dm = new TwitterDirectMessage();
            //dm.RecipientScreenName = "Brienzherelee";
            //// dm.CreatedDate = DateTime.Now;

            //dm = service.GetDirectMessage(dmOp);

            //directMessage = dm.Text;
            //===========================================

            //===========================================
            //Using Tweetinvi------------------------------------------------------------------------------------------

            // Tweetinvi.Auth.SetUserCredentials(consumerKey, ConsumerSecret, AccessToken, AccessTokenSecret);  //works for tweets!
            // Tweet.PublishTweet("test using Tweetinivi library");  //Works!

            //var userCredentials = Auth.CreateCredentials(consumerKey, ConsumerSecret, AccessToken, AccessTokenSecret);
            //var authenticatedUser = User.GetAuthenticatedUser(userCredentials);  //works, authenicated

            //var latestMessagesReceived = authenticatedUser.GetLatestMessagesReceived(1);  //says null!!
            //var latestMessagesSent = authenticatedUser.GetLatestMessagesSent(1);   //returns null!!!!
            //===========================================================================================

            
            //===========================================================================================
            //Linq to Twitter ------- Cannot get this to work at all....

            //LinqTwitter.InMemoryCredentialStore creds = new LinqTwitter.InMemoryCredentialStore();
            //creds.ConsumerKey = consumerKey;
            //creds.ConsumerSecret = ConsumerSecret;
            //creds.OAuthToken = AccessToken;
            //creds.OAuthTokenSecret = AccessTokenSecret;

            //var auth = new LinqTwitter.MvcAuthorizer();
            //auth.CredentialStore = creds;

            //var twitterCtx = new LinqTwitter.TwitterContext(auth);

            //twitterCtx.Authorizer.CredentialStore = creds;          
            // var account =  twitterCtx.Account;
            //===========================================================================================

            return directMessage;
            ;
        }

    }
}
