using AG.Common.Enums;
using AG.Common.Helpers;
using AG.Data.Contracts;
using AG.Data.Services.Helper;
using System;
using System.Threading.Tasks;

namespace AG.Data.Services
{
    public class TweetManager : ITweetManager
    {
        #region Readonly Fields

        private readonly ITweetBuilder _tweetBuilder;
        private readonly IUserBuilder _userBuilder;
      
        #endregion

        #region Fields

        private string _filePath = @"C:\Users\Remote User\source\repos\arch.assess\Docs\";

        #endregion

        #region Ctor

        public TweetManager(ITweetBuilder tweetBuilder, IUserBuilder userBuilder)
        {
            _tweetBuilder = tweetBuilder;
            _userBuilder = userBuilder;          
        }

        #endregion

        #region Methods

        public async Task<bool> Run()
        {
            try
            {
                DisplayGeneralOutput.PrintWelcomeMessage();

                //2. Build List of internal users and followers
                var internalUserFile = FileHelper.BuildFilePath(_filePath, ApplicationEnum.USERFILE);
                var users = _userBuilder.Build(internalUserFile);

                //4. Build a list of tweets
                var internalTweetFile = FileHelper.BuildFilePath(_filePath, ApplicationEnum.TWEETFILE);
                var tweets = _tweetBuilder.Build(internalTweetFile);

                //5. Iterate through list of users
                TweetManagerHelper.IterateThroughUsers(users, tweets);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                DisplayGeneralOutput.DisplayErrorMessage(ex.Message);

                return await Task.FromResult(false);
            }
        }

        #endregion
    }
}
