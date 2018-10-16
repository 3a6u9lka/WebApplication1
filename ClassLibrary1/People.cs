using ClassLibrary1.DataProviders;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace ClassLibrary1
{
    public class People
    {
        public string GetInfo()
        {
            var people = GetPeople(new RandomUserApiDataProvider());

            people.Quote = GeekJokesApiDataProvider.GetQuote();

            using (var dataBase = new DataBaseManager())
            {
                return dataBase.SavePeople(people);
            }
        }


        private PeopleDto GetPeople(IGetPeople provider)
        {
            return provider.GetPeople();
        }
    }
}