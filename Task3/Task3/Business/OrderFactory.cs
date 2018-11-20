//-----------------------------------------------------------------------
// <copyright file="DatabaseTxt.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents creating order
    /// </summary>
    public class OrderFactory : IOrderFactory
    {
        /// <summary>
        /// Implementation of the interface
        /// Create new instance of order
        /// </summary>
        /// <returns> new order </returns>
        public Order CreateOrder()
        {
            return new Order();
        }
    }
}
