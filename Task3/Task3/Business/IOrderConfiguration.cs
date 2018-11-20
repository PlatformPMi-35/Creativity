//-----------------------------------------------------------------------
// <copyright file="IOrderConfiguration.cs" company="Creativity Team">
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
    /// Represents the methods for create configuration
    /// </summary>
    interface IOrderConfiguration
    {
        /// <summary>
        ///  Gets factory of orders
        /// </summary>
        /// <returns>factory of orders</returns>
        IOrderFactory GetFactory();

        /// <summary>
        /// Gets builder of orders
        /// </summary>
        /// <returns>builder of orders</returns>
        IOrderBuilder GetBuilder();

        /// <summary>
        /// Gets validator of orders
        /// </summary>
        /// <returns>validator of orders</returns>
        IOrderValidation GetValidator();

        /// <summary>
        /// Gets object of class that interact with file in txt format
        /// </summary>
        /// <returns>object of class that interact with file in txt format</returns>
        IDatabaseFacade GetDatabase();
    }
}
