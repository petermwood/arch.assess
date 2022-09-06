using AG.Data.Contracts;
using AG.Data.Entities;
using AG.Data.Services.Mocks;
using System.Collections.Generic;
using Xunit;

namespace AG.Tests.Services
{
    public class TweetBuilderTests
    {
        private readonly List<string> _tweetLines;
        private readonly IMockTweetBuilder _tweetBuilder;
       
        public TweetBuilderTests()
        {
            _tweetLines = new List<string>();
            _tweetLines.Add("Alan> If you have a procedure with 10 parameters, you probably missed some.");
            _tweetLines.Add("Ward> There are only two hard things in Computer Science: cache invalidation, naming things and off-by-1 errors.");
            _tweetLines.Add("Alan> Random numbers should not be generated with a method chosen at random.");

            _tweetBuilder = new MockTweetBuilder();

        }

        [Fact]
        public void Create_Tweets_Should_Not_Be_Null()
        {
            var results = _tweetBuilder.BuildTweets(_tweetLines);

            Assert.NotNull(results);
        }

        [Fact]
        public void Create_Tweets_Should_Contain_Three_Tweets()
        {
            var results = _tweetBuilder.BuildTweets(_tweetLines);

            Assert.True(results.Count == 3);
        }

        [Fact]
        public void Create_Tweets_Should_TypeOf_ListOf_Tweet()
        {
            var results = _tweetBuilder.BuildTweets(_tweetLines);

            Assert.True(results.GetType() == typeof(List<Tweet>));
        }

        [Fact]
        public void Create_Single_Tweet_Should_Not_Be_Null()
        {
            var result = _tweetBuilder.BuildTweet(_tweetLines[0]);

            Assert.NotNull(result);
        }

        [Fact]
        public void Create_Single_Tweet_Should_Be_TYpeOf_Tweet()
        {
            var result = _tweetBuilder.BuildTweet(_tweetLines[0]);

            Assert.True(result.GetType() == typeof(Tweet));
        }
    }
}
