using AG.Data.Entities;
using System.Collections.Generic;

namespace AG.Data.Contracts
{
    public interface IMockTweetBuilder
    {
        IList<Tweet> BuildTweets(IList<string> lines);
        Tweet BuildTweet(string line);
    }
}
