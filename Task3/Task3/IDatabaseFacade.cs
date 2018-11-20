using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents interaction with orders details.
    /// </summary>
    public interface IDatabaseFacade
    {
        /// <summary>
        /// Read orders details
        /// </summary>
        /// <returns>List of orders</returns>
        List<Order> ReadOrders();

        /// <summary>
        /// Add order to details about all other orders
        /// </summary>
        /// <param name="order">Information about order</param>
        void AddOrder(Order order);
    }
}
