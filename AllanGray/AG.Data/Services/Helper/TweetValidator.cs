using AG.Common.Enums;

namespace AG.Data.Services.Helper
{
    public static class TweetValidator
    {
        public static string Validate(string value)
        {
            if(value.Length > ApplicationEnum.TWEETLENGTH)
                return value.Substring(0, ApplicationEnum.TWEETLENGTH);

            return value;
        }
    }
}
