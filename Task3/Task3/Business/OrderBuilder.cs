//-----------------------------------------------------------------------
// <copyright file="OrderBuilder.cs" company="Creativity Team">
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
    /// Builder of order 
    /// </summary>
    public class OrderBuilder : IOrderBuilder
    {
        /// <summary>
        /// Factory of order
        /// </summary>
        private IOrderFactory factory;

        /// <summary>
        /// Represents current order  
        /// </summary>
        private Order order;

        /// <summary>
        /// Gets or sets factory of order
        /// </summary>
        public IOrderFactory Factory
        {
            get
            {
                return this.factory;
            }

            set
            {
                this.factory = value;
                this.order = this.factory.CreateOrder();
            }
        }

        /// <summary>
        /// Implementation of the interface
        /// Method for creating new order
        /// </summary>
        /// <returns>current order  </returns>
        public Order Build()
        {
            return this.order;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the address where the client will go
        /// </summary>
        /// <param name="addr">the address where the client will go that will be assigned</param>
        public void SetAddressOfArrival(string addr)
        {
            string[] temp = addr.Split(';');
            this.order.AddressOfArrival = new Address(temp[0], temp[1], temp[2]);
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the address from where the client will go
        /// </summary>
        /// <param name="addr">the address from where the client will go that will be assigned</param>
        public void SetAddressOfDeparture(string addr)
        {
            string[] temp = addr.Split(';');
            this.order.AddressOfDeparture = new Address(temp[0], temp[1], temp[2]);
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the class of car that client wants
        /// </summary>
        /// <param name="classOfCar">the class of car that client wants that will be assigned</param>
        public void SetClassOfTaxi(string classOfCar)
        {
            this.order.ClassOfTheTaxi = (CarClass)Enum.Parse(typeof(CarClass), classOfCar);
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting name of client
        /// </summary>
        /// <param name="name">name that will be assigned</param>
        public void SetName(string name)
        {
            this.order.NameOfClient = name;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting phone number of client
        /// </summary>
        /// <param name="number">phone number that will be assigned</param>
        public void SetPhoneNumber(string number)
        {
            this.order.PhoneNumber = number;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the time when client wants to go
        /// </summary>
        /// <param name="date">the time when client wants to go that will be assigned</param>
        public void SetTimeOfArrival(string date)
        {
            this.order.TimeOfTheArrivalTaxi = DateTime.Parse(date);
        }
    }
}
