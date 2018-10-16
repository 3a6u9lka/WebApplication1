using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Models;

namespace ClassLibrary1.DataProviders
{
    class DataBaseManager : IDisposable
    {
        private readonly SqlConnection _connection;

        internal DataBaseManager()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoSite"].ConnectionString);
            _connection.Open();
        }

        public string SavePeople(PeopleDto people)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "[dbo].[spSavePeopleData]";
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@Gender", people.Gender);
                command.Parameters.AddWithValue("@FirstName", people.FirstName);
                command.Parameters.AddWithValue("@LastName", people.LastName);
                command.Parameters.AddWithValue("@Quote", people.Quote);

                return command.ExecuteScalar().ToString();
            }

        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
