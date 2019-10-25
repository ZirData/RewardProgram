using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBConnect;
using Customers;
using Transactions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class RewardsController : Controller
    {
        SqlConnect sqlConnection = new SqlConnect();
        public RewardsController() { }

        [HttpGet]
        public IActionResult getRewards()
        {
            List<Customer> customers = sqlConnection.getCustomers();
            List<Transaction> transactions = sqlConnection.getTransactions();
            List<Customer> updatedList = new List<Customer>();
            string message = "bad";
            
            foreach(var transaction in transactions)
            {
                int points = 0;
                if (transaction.amount > 50 && transaction.amount >= 100)
                    points = transaction.amount - 50;
                if (transaction.amount > 100)
                    points = 50 + 2 * (transaction.amount - 100);
                for(int i = 0; i < customers.Count; i++)
                {
                    if (customers[i].id == transaction.customerId)
                    {

                        Customer updateCustomer = new Customer(customers[i].id, points, customers[i].name);
                        customers[i] = updateCustomer;
                    }
                }
                
            }
            return  Ok(customers);
        }
    }
}
