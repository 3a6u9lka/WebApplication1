using Project1.DataProviders;
using Project1.Interfaces;

namespace Project1
{
    public class People
    {
        public string GetInfo()
        {
            IGetPeople provider = new RandomUserApiDataProvider();
            var people = provider.GetPeople();

            people.Quote = GeekJokesApiDataProvider.GetQuote().Result;

            var dataBase = new DataBaseManager();
            return dataBase.SavePeople(people);
        }
    }
}