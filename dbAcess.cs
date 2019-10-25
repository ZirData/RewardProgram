using System;
using MySql.Data.MySqlClient;

namespace SqlConnect
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        //Constructor
        public DBConnect()
        {
            server = "localhost";
            database = "customers";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";";

            connection = new MySqlConnection(connectionString);
        }

        public bool openConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Cannot connect to server.  Contact administrator");
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}