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
using System.IO;

namespace Task3
{
    /// <summary>
    /// Represents interaction with orders details in txt format
    /// </summary>
    public class DatabaseTxt : IDatabaseFacade
    {
        /// <summary>
        /// Path to file where details about orders are
        /// </summary>
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref = "DatabaseTxt" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="filePath_">path to file where details about orders are</param>
        public DatabaseTxt(string filePath_)
        {
           this.filePath = filePath_;
        }

        /// <summary>
        /// Add order to details about all other orders 
        /// </summary>
        /// <param name="order">The order information that will be written to the file</param>
        public void AddOrders(Order order)
        {
            string[] towrite = { order.ToString() };
            File.AppendAllLines(this.filePath, towrite);
        }

        /// <summary>
        /// Read orders details from txt file
        /// </summary>
        /// <returns>List of orders</returns>
        public List<Order> ReadOrders()
        {
            List<Order> toret = new List<Order>();
            string[] res = File.ReadAllLines(this.filePath);
            for (int i = 0; i < res.Length; ++i) 
            {
                string[] parse = res[i].Split(' ');
                toret.Add(new Order(parse[0], parse[1], new Address(parse[2], parse[3]), new Address(parse[4], parse[5]), DateTime.Parse(parse[6]), (CarClass)Enum.Parse(typeof(CarClass), parse[7])));
            }

            return toret;
        }

    }
}
