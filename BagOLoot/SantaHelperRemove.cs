// using System.Collections.Generic;

// namespace BagOLoot
// {
//     public class SantaHelperRemove
//     {
//         public void RemoveToyFromChild(int toyId, int childId)
//         {
//             // Return the new toy id
//         }

//         public List<int> GetChildsToys(int toys)
//         {
//             return new List<int>() {4, 6, 7, 8};
//         }
//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class SantaHelperRemove
    {
        private List<string> _childToys = new List<string>();
        private List<string> _toyIds = new List<string>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public SantaHelperRemove()
        {
            _connection = new SqliteConnection(_connectionString);
        }


        public List<string> GetChildsToys(int childId)
        {
             using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // get toys according to child id
                dbcmd.CommandText = $"select name from toy where childid = '{childId}';";
                dbcmd.ExecuteNonQuery ();
                using (SqliteDataReader dr = dbcmd.ExecuteReader()) 
                {
                    while(dr.Read()) {
                        _childToys.Add(dr[0].ToString()); //Add child name to the list
                    }
                }
                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return _childToys;
        }
        public int RemoveToyFromChild(string toyName, int childId) 
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                // Delete row from a table when two conditions met
                dbcmd.CommandText = $"delete from toy where name = '{toyName}' and childId = '{childId}'";
                dbcmd.ExecuteNonQuery ();
                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }

            return 45;
        }
    }
}