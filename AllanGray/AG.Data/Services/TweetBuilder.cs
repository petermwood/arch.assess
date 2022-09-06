using AG.Common.Helpers;
using AG.Data.Contracts;
using AG.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AG.Data.Services
{
    public class TweetBuilder : ITweetBuilder
    {
        #region Readonly Fields

        private readonly IFileReader _fileReader;
      
        #endregion

        #region Constants

        private const string SEPARATOR = ">";

        #endregion

        #region Ctor

        public TweetBuilder(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        #endregion

        #region Public Methods

        public IList<Tweet> Build(string filePath)
        {
            var lines = ReadLines(filePath);

            return BuildTweets(lines);
        }

        #endregion

        #region Private Methods

        private IList<Tweet>BuildTweets(IList<string>lines)
        {
            var tweets = new List<Tweet>();

            lines.ToList().ForEach (x =>
             {
                 var tweet = BuildTweet(x);

                 if(tweet != null)
                 {
                     tweets.Add(tweet);
                 }
             });

            return tweets;
        }

        private Tweet BuildTweet(string line)
        {
            if (!StringHelper.Contains(line, SEPARATOR))
                throw new ArgumentException("Invalid tweet");

            var results = line.Split(SEPARATOR);

            if(results.Length == 2)
            {
                return new Tweet(results[0], results[1]);
            }

            return null;
        }

        private IList<string> ReadLines(string filePath)
        {
            try
            {
                var lines = _fileReader.Read(filePath);
                return lines;

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
