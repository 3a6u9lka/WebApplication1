using System.Net;

namespace ClassLibrary1.DataProviders
{
    public class GeekJokesApiDataProvider
    {
        private static readonly string _url = "https://geek-jokes.sameerkumar.website/api";

        public static string GetQuote()
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadString(_url);
            }
        }
    }
}
