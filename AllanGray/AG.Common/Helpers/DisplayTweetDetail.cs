using System;
using System.Threading;

namespace AG.Common.Helpers
{
    public static class DisplayTweetDetail
    {
        public static void DisplayHeader(string param)
        {
            Thread.Sleep(500);
            Console.WriteLine("{0,5}", param);
        }

        public static void DisplayDetail(string param, string param1)
        {
            Thread.Sleep(2000);
            Console.WriteLine("{0,10} : {1,10}", "@" + param, param1);
        }
    }
}
