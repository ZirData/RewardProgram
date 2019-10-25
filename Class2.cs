using System;
namespace transaction
{
    public class transaction
    {
        public int customerId;
        public int amount;
        public transaction(int customerId, int amount)
        {
            this.customerId = customerId;
            this.amount = amount;
        }
    }
}