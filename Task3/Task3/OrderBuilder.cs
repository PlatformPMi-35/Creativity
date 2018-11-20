using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderBuilder : IOrderBuilder
    {
        private IOrderFactory factory;

        /// <summary>
        /// Gets or sets factory of order
        /// </summary>
        public IOrderFactory Factory {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
                order = factory.CreateOrder();
            }
        }

        /// <summary>
        /// Represents current order  
        /// </summary>
        private Order order;

        /// <summary>
        /// Implementation of the interface
        /// Method for creating new order
        /// </summary>
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
            order.AddressOfArrival = new Address(temp[0], temp[1], temp[2]);
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the address from where the client will go
        /// </summary>
        /// <param name="addr">the address from where the client will go that will be assigned</param>

        public void SetAddressOfDeparture(string addr)
        {
            string[] temp = addr.Split(';');
            order.AddressOfDeparture = new Address(temp[0], temp[1], temp[2]);
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the class of car that client wants
        /// </summary>
        /// <param name="classOfCar">the class of car that client wants that will be assigned</param>
        public void SetClassOfTaxi(string classOfCar)
        {
            order.ClassOfTheTaxi= (CarClass)Enum.Parse(typeof(CarClass), classOfCar);
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting name of client
        /// </summary>
        /// <param name="name">name that will be assigned</param>
        public void SetName(string name)
        {
            order.NameOfClient = name;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting phone number of client
        /// </summary>
        /// <param name="number">phone number that will be assigned</param>
        public void SetPhoneNumber(string number)
        {
            order.PhoneNumber = number;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the time when client wants to go
        /// </summary>
        /// <param name="date">the time when client wants to go that will be assigned</param>

        public void SetTimeOfArrival(string date)
        {
            order.TimeOfTheArrivalTaxi = DateTime.Parse(date);
        }

    }
}
