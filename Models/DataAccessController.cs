using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentUsersApp.Models
{
    public class DataAccessController
    {
        // TODO: Add your connection string in the following statements
        string connectionString = "<Azure Database for PostgreSQL Connection String>";

        // Retrieve all details of courses and their modules    
        public IEnumerable<Users> GetAllUsers()
        {
            List<Users> userList = new List<Users>();

            // TODO: Connect to the database
            //using ()
            using(var conn=new NpgsqlConnection(connectionString))
            {
                Console.Out.WriteLine("Opening connection");
                string selectQuery = "SELECT * FROM payment_users";
                using(var command = new NpgsqlCommand(selectQuery,conn))
                {
                    var reader = command.ExecuteReader();
                    while(reader.Read()){
                        String userID = reader.GetInt32(0).ToString();
                        string userName = reader.GetString(1);
                        var age = reader.GetInt32(2);
                        Users user = new Users(userID,userName,age);
                        userList.Add(user);
                    }
                }

                // TODO: Specify the SQL query to run

                // TODO: Execute the query

                // TODO: Read the data a row at a time
            
                // TODO: Close the database connection
            }
            return userList;
        }
    }
}
