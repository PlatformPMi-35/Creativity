//-----------------------------------------------------------------------
// <copyright file="OrderFactory.cs" company="Creativity Team">
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
    public interface IOrderFactory
    {
        /// <summary>
        /// Represents method for creating order
        /// </summary>
        /// <returns>order that was created</returns>
        Order CreateOrder();
    }
}
