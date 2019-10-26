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
            return Ok(Customer.calculateRewards(transactions,customers));
            
        }

        [HttpGet("months"]
        public IActionResult getMonthlyRewards([FromBody] string date)
        {
            
            List<Customer> customers = sqlConnection.getCustomers();
            List<Transaction> transactions = sqlConnection.getMonthlyTransactions(Convert.ToDateTime(date));
            return Ok(Customer.calculateMonthlyRewards(transactions, customers));

        }
    }
}
