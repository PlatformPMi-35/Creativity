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
    public class Order
    {
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
        /// Gets or sets NameOfClient property
        /// </summary>
        public string NameOfClient
        {
            get
            {
                return nameOfClient;
            }
            set
            {
                nameOfClient = value;
            }
        }

        /// <summary>
        /// Gets or sets PhoneNumber property
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                
                phoneNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets AddressOfDeparture property
        /// </summary>
        public Address AddressOfDeparture
        {
            get
            {
                return addressOfDeparture;
            }
            set
            {
                addressOfDeparture = value;
            }
        }

        /// <summary>
        /// Gets or sets AddressOfArrival property
        /// </summary>
        public Address AddressOfArrival
        {
            get
            {
                return addressOfArrival;
            }
            set
            {
                addressOfArrival = value;
            }
        }

        /// <summary>
        ///  Gets or sets TimeOfTheArrivalTaxi property
        /// </summary>
        public DateTime TimeOfTheArrivalTaxi
        {
            get
            {
                return timeOfTheArrivalTaxi;
            }
            set
            {
                timeOfTheArrivalTaxi = value;
            }
        }

        /// <summary>
        /// Gets or sets ClassOfTheTaxi property
        /// </summary>
        public CarClass ClassOfTheTaxi
        {
            get
            {
                return classOfTheTaxi;
            }
            set
            {
                classOfTheTaxi = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Order" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public Order() { }

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
            NameOfClient = name;
            PhoneNumber = phone;
            AddressOfDeparture = dep;
            AddressOfArrival = arr;
            TimeOfTheArrivalTaxi = arrTime;
            ClassOfTheTaxi = classOfCar;
        }

        public override string ToString()
        {
            return NameOfClient+";"+PhoneNumber+";"+AddressOfDeparture.ToString()+";"+addressOfArrival.ToString()+";"+
                TimeOfTheArrivalTaxi.ToString()+";"+ClassOfTheTaxi.ToString();
        }
    }
}
