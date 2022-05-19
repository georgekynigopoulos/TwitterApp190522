using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace TwitterApp190522
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var userCredentials = new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            var userClient = new TwitterClient(userCredentials);


            // Create a simple stream containing only tweets with the keyword France

            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("java");
            stream.AddTrack("python");
            stream.AddTrack("csharp");
            stream.AddTrack("javascript");

            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;


            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                string tweet = eventReceived.Tweet.FullText;
                                
                Console.WriteLine(tweet);

                if ( tweet.Contains("java"))
                {
                    counter1++;
                }
                if ( tweet.Contains("python"))
                {
                    counter2++;
                }                    
                if ( tweet.Contains("csharp"))
                {
                    counter3++;
                }
                if ( tweet.Contains("javascript"))
                {
                    counter4++;
                }





            };

            await stream.StartMatchingAnyConditionAsync();

        }
    }
}
