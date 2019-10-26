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
        public List<int?> monthlyPoints;
        public Customer(int id, int points, string name, List<int?> monthlyPoints)
        {
            this.name = name;
            this.id = id;
            this.totalPoints = points;
            this.monthlyPoints = monthlyPoints;
        }
        public static List<Customer> calculateRewards(List<Transaction> transactions, List<Customer> customers)
        {
           
            foreach (var transaction in transactions)
            {
                int points = 0;
                if (transaction.amount > 50 && transaction.amount >= 100)
                    points = transaction.amount - 50;
                if (transaction.amount > 100)
                    points = 50 + 2 * (transaction.amount - 100);
                for (int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].id == transaction.customerId)
                    {

                        Customer updateCustomer = new Customer(customers[i].id, points, customers[i].name,null);
                        customers[i] = updateCustomer;
                    }
                }

            }
            return customers;
        }
    }
}
