using AG.Common.Helpers;
using AG.Data.Contracts;
using AG.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AG.Data.Services.Mocks
{
    public class MockTweetBuilder: IMockTweetBuilder
    {
        #region Constants

        private const string SEPARATOR = ">";

        #endregion

        #region Methods

        public IList<Tweet> BuildTweets(IList<string> lines)
        {
            var tweets = new List<Tweet>();

            lines.ToList().ForEach(x =>
            {
                var tweet = BuildTweet(x);

                if (tweet != null)
                {
                    tweets.Add(tweet);
                }
            });

            return tweets;
        }
        public Tweet BuildTweet(string line)
        {
            if (!StringHelper.Contains(line, SEPARATOR))
                throw new ArgumentException("Invalid tweet");

            var results = line.Split(SEPARATOR);

            if (results.Length == 2)
            {
                return new Tweet(results[0], results[1]);
            }

            return null;
        }

        #endregion
    }
}
