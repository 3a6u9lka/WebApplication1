using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Interfaces;
using Project1.Models;

namespace Project1.DataProviders
{
    class DataBaseManager : ISavePeople
    {
        private SqlConnection _connection;

        internal DataBaseManager()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoSite"].ConnectionString);
        }

        public string SavePeople(PeopleDto people)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "[dbo].[spSavePeopleData]";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@FirstName", people.FirstName);
                command.Parameters.AddWithValue("@LastName", people.LastName);
                command.Parameters.AddWithValue("@Quote", people.Quote);

                return command.ExecuteScalar().ToString();
            }

        }
    }
}
