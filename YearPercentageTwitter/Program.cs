using System;
using Tweetinvi;
using System.Threading.Tasks;
using ApiKeys;

namespace YearPercentageTwitter
{
    class Program
    {
        static async Task Main()
        {
            

            TwitterClient UserClient = new TwitterClient(ApiKeysLibrary.ApiKey, ApiKeysLibrary.ApiSecretKey, ApiKeysLibrary.AccessToken, ApiKeysLibrary.AccessSecretToken);
            var user = await UserClient.Users.GetAuthenticatedUserAsync();
            string newTweet = Convert.ToString($"We are {YearPercentage()}% through the year!");
            var tweet = await UserClient.Tweets.PublishTweetAsync(newTweet);

            Console.WriteLine("Tweet Successful");

        }

        //Get the percentage of the year
        private static double YearPercentage()
        {
            double dayOfYear = DateTime.Now.DayOfYear;
            double percentageOfYear = dayOfYear / 365 * 100;
            percentageOfYear = Math.Round(percentageOfYear, 0);
            return percentageOfYear;
        }


    }
}
