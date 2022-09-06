using AG.Common.Helpers;
using AG.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AG.Data.Services.Helper
{
    public static class TweetManagerHelper
    {
        public static void IterateThroughUsers(IList<User> users, IList<Tweet> tweets)
        {
            foreach (var user in users)
            {
                //6.  >>  Get tweet(s) per user 
                var tweetsToBePrinted = tweets.Where(y => y.User.Equals(user.Name)).ToList();
                if (tweetsToBePrinted.Count == 0)
                    continue;

                //7.  >>  Print user
                DisplayTweetDetail.DisplayHeader(user.Name);

                foreach (var t in tweetsToBePrinted)
                {
                    //8.  >>  Validate tweet size
                    //9.  >>  Print first 140 characters of tweet.
                    DisplayTweetDetail.DisplayDetail(t.User, TweetValidator.Validate(t.Message));
                }
                Console.WriteLine("");
            }
        }
    }
}
