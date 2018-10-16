using System.Net.Http;
using System.Threading.Tasks;

namespace Project1.DataProviders
{
    public class GeekJokesApiDataProvider
    {
        private static readonly string _url = "https://geek-jokes.sameerkumar.website/api";

        public static async Task<string> GetQuote()
        {
            string people = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(_url);
                if (response.IsSuccessStatusCode)
                {
                    people = await response.Content.ReadAsStringAsync();
                }
            }

            return people;
        }
    }
}
