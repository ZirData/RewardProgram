using System;
namespace Transactions
{
    public class Transaction
    {
        public int customerId;
        public int amount;
        public Transaction(int customerId, int amount)
        {
            this.customerId = customerId;
            this.amount = amount;
        }
    }
}