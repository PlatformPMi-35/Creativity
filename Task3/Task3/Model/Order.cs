
//-----------------------------------------------------------------------
// <copyright file="Order.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Enumeration of cars class
    /// </summary>
    public enum CarClass
        {
        /// <summary>
        /// Represent economy class car
        /// </summary>
        Economy,

        /// <summary>
        /// Represent comfort class car
        /// </summary>
        Comfort,

        /// <summary>
        /// Represent minibus class car
        /// </summary>
        Minibus,

        /// <summary>
        /// Represent station wagon class car
        /// </summary>
        StationWagon,

        /// <summary>
        /// Represent driver class
        /// </summary>
        Driver
    }

    /// <summary>
    /// Represents an instance order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Represents an id of address
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Represents the name of client
        /// </summary>
        public string NameOfClient { get; set; }

        /// <summary>
        /// Represents the client`s phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Represents the address from where the client will go
        /// </summary>
        public Address AddressOfDeparture { get; set; }

        /// <summary>
        /// Represents the address where the client will go
        /// </summary>
        public Address AddressOfArrival { get; set; }

        /// <summary>
        /// Represents the time when client wants to go
        /// </summary>
        public DateTime TimeOfTheArrivalTaxi { get; set; }

        /// <summary>
        /// Represents the class of car that client wants
        /// </summary>
        public CarClass ClassOfTheTaxi { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Order" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Order" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="name">name of client</param>
        /// <param name="phone">phone number of client</param>
        /// <param name="dep">address from where the client will go </param>
        /// <param name="arr">address where the client will go</param>
        /// <param name="arrTime">the time when client wants to go</param>
        /// <param name="classOfCar">the class of taxi that client wants</param>
        public Order(string name, string phone, Address dep, Address arr, DateTime arrTime, CarClass classOfCar)
        {
            this.NameOfClient = name;
            this.PhoneNumber = phone;
            this.AddressOfDeparture = dep;
            this.AddressOfArrival = arr;
            this.TimeOfTheArrivalTaxi = arrTime;
            this.ClassOfTheTaxi = classOfCar;
        }


        /// <summary>
        /// Override method, that get the string of address 
        /// </summary>
        /// <returns>string of order</returns>
        public override string ToString()
        {
            return this.NameOfClient + ";" + this.PhoneNumber + ";" + this.AddressOfDeparture.ToString() + ";" + this.AddressOfArrival.ToString() + ";" + this.TimeOfTheArrivalTaxi.ToString() + ";" + this.ClassOfTheTaxi.ToString();
        }
    }
}
