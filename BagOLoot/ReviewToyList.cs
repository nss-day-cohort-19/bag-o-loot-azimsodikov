using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class ReviewChildsToyList
    {
        Dictionary<int, string> _children = new Dictionary<int, string>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public ReviewChildsToyList()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        public Dictionary<int, string> GetChildsToyList()
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand();

                // Get the name of all the children
                dbcmd.CommandText = $"select id, name from child where delivered = 1;";
                dbcmd.ExecuteNonQuery ();
                // Get all the names
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    while(dr.Read()) {
                        if(_children.ContainsKey(dr.GetInt32(0)))
                        {

                        }
                        else
                        {
                            _children.Add(dr.GetInt32(0), dr[1].ToString());
                        } //Add child name and id to the list
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