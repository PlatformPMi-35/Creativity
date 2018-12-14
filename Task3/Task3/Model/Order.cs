
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
        private int id;

        /// <summary>
        /// Represents the name of client
        /// </summary>
        private string nameOfClient;

        /// <summary>
        /// Represents the client`s phone number
        /// </summary>
        private string phoneNumber;

        /// <summary>
        /// Represents the address from where the client will go
        /// </summary>
        private Address addressOfDeparture;

        /// <summary>
        /// Represents the address where the client will go
        /// </summary>
        private Address addressOfArrival;

        /// <summary>
        /// Represents the time when client wants to go
        /// </summary>
        private DateTime timeOfTheArrivalTaxi;

        /// <summary>
        /// Represents the class of car that client wants
        /// </summary>
        private CarClass classOfTheTaxi;

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
        /// Gets or sets Id property
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets NameOfClient property
        /// </summary>
        public string NameOfClient
        {
            get
            {
                return this.nameOfClient;
            }

            set
            {
                this.nameOfClient = value;
            }
        }

        /// <summary>
        /// Gets or sets PhoneNumber property
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets AddressOfDeparture property
        /// </summary>
        public Address AddressOfDeparture
        {
            get
            {
                return this.addressOfDeparture;
            }

            set
            {
                this.addressOfDeparture = value;
            }
        }

        /// <summary>
        /// Gets or sets AddressOfArrival property
        /// </summary>
        public Address AddressOfArrival
        {
            get
            {
                return this.addressOfArrival;
            }

            set
            {
                this.addressOfArrival = value;
            }
        }

        /// <summary>
        ///  Gets or sets TimeOfTheArrivalTaxi property
        /// </summary>
        public DateTime TimeOfTheArrivalTaxi
        {
            get
            {
                return this.timeOfTheArrivalTaxi;
            }

            set
            {
                this.timeOfTheArrivalTaxi = value;
            }
        }

        /// <summary>
        /// Gets or sets ClassOfTheTaxi property
        /// </summary>
        public CarClass ClassOfTheTaxi
        {
            get
            {
                return this.classOfTheTaxi;
            }

            set
            {
                this.classOfTheTaxi = value;
            }
        }

        /// <summary>
        /// Override method, that get the string of address 
        /// </summary>
        /// <returns>string of order</returns>
        public override string ToString()
        {
            return this.NameOfClient + ";" + this.PhoneNumber + ";" + this.AddressOfDeparture.ToString() + ";" + this.addressOfArrival.ToString() + ";" + this.TimeOfTheArrivalTaxi.ToString() + ";" + this.ClassOfTheTaxi.ToString();
        }
    }
}
