using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;
using Newtonsoft.Json;

namespace ClassLibrary1.DataProviders
{
    internal class RandomUserApiDataProvider : IGetPeople
    {
        private readonly string _peopleUrl = "https://randomuser.me/api/";

        private async Task<RootObject> GetAsyncPeople()
        {

            RootObject people = null;

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(_peopleUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var reader = await response.Content.ReadAsStringAsync();

                    people = JsonConvert.DeserializeObject<RootObject>(reader);
                }
            }

            return people;
        }

        public PeopleDto GetPeople()
        {
            var data = GetAsyncPeople().Result;

            if (data == null || !data.Results.Any())
                return null;

            var people = data.Results.First();

            return new PeopleDto
            {
                FirstName = people.Name.First,
                Gender = people.Gender,
                LastName = people.Name.Last,
            };
        }
    }
}
