using AG.Common.Enums;
using AG.Common.Helpers;
using AG.Data.Contracts;
using System;
using System.Linq;
using System.Threading;
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

        private string _filePath = @"C:\dev\github\assessments\johanccs\Docs\";

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
                //2. Build List of internal users and followers
                var internalUserFile = FileHelper.BuildFilePath(_filePath, ApplicationEnum.USERFILE);
                var users = _userBuilder.Build(internalUserFile);

                //4. Build a list of tweets
                var internalTweetFile = FileHelper.BuildFilePath(_filePath, ApplicationEnum.TWEETFILE);
                var tweets = _tweetBuilder.Build(internalTweetFile);

                //5. Iterate through list of users
                foreach (var user in users)
                {
                    //6.  >>  Get tweet(s) per user 
                    var tweetsToBePrinted = tweets.Where(y => y.User.Equals(user.Name)).ToList();
                    if (tweetsToBePrinted.Count == 0)
                        continue;

                    //7.  >>  Print user
                    Thread.Sleep(2000);
                    Console.WriteLine("{0,5}", user.Name);
                    foreach (var t in tweetsToBePrinted)
                    {
                        Thread.Sleep(1000);
                        //8.  >>  Validate tweet size
                        //9.  >>  Print first 140 characters of tweet.
                        Console.WriteLine("{0,10} : {1,10}", "@" + t.User, t.Message);
                    }
                    Console.WriteLine("");
                }

                PrintMessageFooter();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        private static void PrintMessageFooter()
        {
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }


        #endregion
    }
}
