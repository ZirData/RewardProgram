using System;
using System.Collections.Generic;
using Transactions;

namespace Customers
{
    public class Customer
    {
        public string name;
        public int id;
        public int? totalPoints;
        public Customer(int id, int points, string name)
        {
            this.name = name;
            this.id = id;
            this.totalPoints = points;
        }
        public static List<Customer> calculateRewards(List<Transaction> transactions, List<Customer> customers)
        {
            List<Customer> updatedCustomers = new List<Customer>();
            foreach (var customer in customers)
            {
                int points = 0;
                foreach (var transaction in transactions)
                {
                    if (transaction.customerId == customer.id)
                    {
                        if (transaction.amount > 50 && transaction.amount <= 100)
                            points += transaction.amount - 50;
                        if (transaction.amount > 100)
                            points += 50 + 2 * (transaction.amount - 100);
                    }

                }
                Customer updateCustomer = new Customer(customer.id, points, customer.name);
                updatedCustomers.Add(updateCustomer);
            }
            return updatedCustomers;
        }
        public static List<int> calculateMonthlyRewards(List<Transaction> transactions, List<Customer> customers)
        {
                // foreach customer add up transactions that belong to them for the month
                List<int> listOfPoints = new List<int>();
                    
            foreach (var customer in customers)
            {
                int points = 0;
                foreach (var transaction in transactions)
                {
                    if (transaction.customerId == customer.id)
                    {
                        if (transaction.amount > 50 && transaction.amount <= 100)
                            points += transaction.amount - 50;
                        if (transaction.amount > 100)
                            points += 50 + 2 * (transaction.amount - 100);
                    }

                }
                listOfPoints.Add(points);
            }

            return listOfPoints;
        }
    }
}
