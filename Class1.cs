using System;

namespace Customers
{
    public class Customer
    {
        public string name;
        public int id;
        public int points;
        public Customer(int id, int points, string name)
        {
            this.name = name;
            this.id = id;
            this.points = points;
        }
    }
}
