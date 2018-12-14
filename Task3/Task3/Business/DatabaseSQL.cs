//-----------------------------------------------------------------------
// <copyright file="DatabaseSQL.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    /// <summary>
    /// Represents interaction with orders details in sql format
    /// </summary>
    public class DatabaseSQL : IDatabaseFacade
    {
        /// <summary>
        /// Path to file where details about orders are
        /// </summary>
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref = "DatabaseSQL" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="filePath_">path to file where details about orders are</param>
        public DatabaseSQL(string filePath_)
        {
            this.filePath = filePath_;
        }

        /// <summary>
        /// Add order to details about all other orders 
        /// </summary>
        /// <param name="order">The order information that will be written to the file</param>
        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read orders details from database
        /// </summary>
        /// <returns>List of orders</returns>
        public List<Order> ReadOrders()
        {
            throw new NotImplementedException();
        }
    }
}
