using System;
namespace Transactions
{
    public class Transaction
    {
        public int customerId;
        public int amount;
        public DateTime date;
        public Transaction(int customerId, int amount, DateTime date)
        {
            this.customerId = customerId;
            this.amount = amount;
            this.date = date;
        }
    }
}