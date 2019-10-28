using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBConnect;
using Customers;
using Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

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
        
        [HttpPost("months")]
        public IActionResult getMonthlyRewards([FromBody] JObject date)
        {
            int month = (int)date.SelectToken("date");
            List<Customer> customers = sqlConnection.getCustomers();
            List<Transaction> transactions = sqlConnection.getMonthlyTransactions(month);
            return Ok(JsonConvert.SerializeObject(Customer.calculateMonthlyRewards(transactions, customers)));

        }
    }
}
