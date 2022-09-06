namespace AG.Data.Entities
{
    public class Tweet
    {
        public string User { get; private set; }

        public string Message { get; private set; }

        public Tweet(string user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
