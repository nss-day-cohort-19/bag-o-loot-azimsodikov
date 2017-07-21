// using System.Collections.Generic;

// namespace BagOLoot
// {
//     public class CheckDelivered
//     {
//         public bool IsToyDelivered(int childId)
//         {
        

//             return true;
//         }
//     }
// }
// using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace BagOLoot
{
    public class CheckDelivered
    {
         private List<string> _children = new List<string>();
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BAGOLOOT_DB")}";
        private SqliteConnection _connection;

        public CheckDelivered()
        {
            _connection = new SqliteConnection(_connectionString);
        }
        public bool IsToyDelivered(int childId)
        {
            bool check = true;
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand();
                // Get the name of all the children
                try{
                dbcmd.CommandText = $"update child set delivered = 1 where id = {childId} ";
                Console.WriteLine(dbcmd.CommandText);
                dbcmd.ExecuteNonQuery ();
                }catch(Exception)
                {
                    check = false;
                }
                // clean up
                dbcmd.Dispose ();
                _connection.Close ();
            }
            return check;
        }
    }
}