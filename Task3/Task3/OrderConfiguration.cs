using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents configuretion order
    /// </summary>
    class OrderConfiguration :IOrderConfiguration
    {
        /// <summary>
        /// Implementation of the interface.
        /// Create new factory of orders
        /// </summary>
        /// <returns>new factory of orders</returns>
        public IOrderFactory GetFactory()
        {
            return new OrderFactory();
        }

        /// <summary>
        /// Implementation of the interface.
        /// Create new builder of orders
        /// </summary>
        /// <returns>new builder of orders</returns>
        public IOrderBuilder GetBuilder()
        {
            return new OrderBuilder();
        }

        /// <summary>
        /// Implementation of the interface.
        /// Create new validator of orders
        /// </summary>
        /// <returns>new validator of orders</returns>
        public IOrderValidation GetValidator()
        {
            return new OrderValidation();
        }

        /// <summary>
        /// Implementation of the interface.
        /// Create new object of class that interact with file in txt format
        /// </summary>
        /// <returns>new object of class that interact with file in txt format</returns>
        public IDatabaseFacade GetDatabase()
        {
            return new DatabaseTxt("database.txt");
        }

    }
}
