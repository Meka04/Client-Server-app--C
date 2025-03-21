using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Project.model
{
    public class DBConnection
    {
        private const string connectionString = @"Data Source=D:\Info\Projects\University\Y2\S2\Client-Server-app--C\Database.db";
        private IDbConnection connection;
        public DBConnection() {
            connection = new SQLiteConnection(connectionString);
            connection.Open();
            Console.WriteLine("Database connection: on.");
        }

        public IDbConnection getConnection() {
            return connection;
        }

        public void CloseConnection() {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Database connection: off.");
            }
        }
    }
}
