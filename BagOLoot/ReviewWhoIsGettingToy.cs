using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
namespace BagOLoot
{
    public class ReviewWhoIsGettingToy
    {
        Dictionary<string, int> _children = new Dictionary<string, int>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ReviewWhoIsGettingToy()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        public Dictionary<string, int> GetChildrenWithToy()
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Get the name of all the children
                dbcmd.CommandText = $"select Name, id from Child";
                dbcmd.ExecuteNonQuery ();
                // Get all the names
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    while(dr.Read()) {
                       _children.Add(dr[0].ToString(), Convert.ToInt32(dr[1]));  //Add child name and id to the list
                    }
                }

                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return _children;
        }
    }
}