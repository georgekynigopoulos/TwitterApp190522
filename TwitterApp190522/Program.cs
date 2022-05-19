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

            string filter1 = "java";
            string filter2 = "python";
            string filter3 = "csharp";
            string filter4 = "javascript";


            // Create a simple stream containing only tweets with the keyword France

            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack(filter1);
            stream.AddTrack(filter2);
            stream.AddTrack(filter3);
            stream.AddTrack(filter4);

            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;


            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                string tweet = eventReceived.Tweet.FullText;
                                
                Console.WriteLine(tweet);

                if ( tweet.Contains(filter1))
                {
                    counter1++;
                }
                if ( tweet.Contains(filter2))
                {
                    counter2++;
                }                    
                if ( tweet.Contains(filter3))
                {
                    counter3++;
                }
                if ( tweet.Contains(filter4))
                {
                    counter4++;
                }


                Console.WriteLine(
                    filter1 + ":" + counter1 + ", " +
                    filter2 + ":" + counter2 + ", " +
                    filter3 + ":" + counter3 + ", " +
                    filter4 + ":" + counter4 
                );

                // java: 8, python: 4, csharp: 0, javascript: 5


            };

            await stream.StartMatchingAnyConditionAsync();

        }
    }
}
