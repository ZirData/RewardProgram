using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Customers;
using Transactions;


namespace DBConnect
{
    public class SqlConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string connectionString;
        private string uid;
        private string password;
        //Constructor
        public SqlConnect()
        {
            uid = "root";
            password = "root";
            server = "localhost";
            database = "Rewards";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
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
                string message = "Cannot connect to server.  Contact administrator";
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
                string message = "Cannot close connection";
                return false;
            }
        }
        public List<Transaction> getTransactions()
        {
            connection = new MySqlConnection(connectionString);
            List <Transaction> transactions = new List<Transaction>(); //would of made forign key for id but time crunch 
            this.openConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM transactions", connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                
                int customerId = (int)(dataReader["customerId"]);
                int amount = (int)(dataReader["amount"]);
                Transaction transaction = new Transaction(customerId,amount);
                transactions.Add(transaction);

            }
            this.CloseConnection();
            return transactions;
        }
        public List<Customer> getCustomers()
        {
            connection = new MySqlConnection(connectionString);
            List<Customer> customers = new List<Customer>(); //would of made forign key for id but time crunch 
            this.openConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM customers", connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                
                int customerId = (int)(dataReader["id"]);
                int points = (int)dataReader["points"];
                string name = dataReader["name"].ToString();
                Customer customer = new Customer(customerId,points,name);
                customers.Add(customer);

            }
            this.CloseConnection();
            return  customers;
        }
        public void updatePoints(List<Customer> customers)
        {
            connection = new MySqlConnection(connectionString);
            this.openConnection();
            foreach(var customer in customers)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE customers SET points="+customer.points + "where customers.id =" + customer.id +";", connection);
            }
            this.CloseConnection();
        }

    }
}