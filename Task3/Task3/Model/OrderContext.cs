using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task3.Model
{
    public class OrderContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public OrderContext() : base("OrderContext")
        {

        }
    }
}
