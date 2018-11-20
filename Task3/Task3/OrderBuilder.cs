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
        /// <summary>
        /// Represents current order  
        /// </summary>
        private Order order;
        
        /// <summary>
        /// Gets or sets factory of order
        /// </summary>
        public IOrderFactory Factory { get; set; }

        /// <summary>
        /// Implementation of the interface
        /// Method for creating new order
        /// </summary>
        public void Build()
        {
            this.Factory = new OrderFactory();
            this.order = this.Factory.CreateOrder();
        }

        /// <summary>
        /// Implementation of the interface.
        ///  Method for getting current order
        /// </summary>
        /// <returns>current order</returns>
        public Order GetOrder()
        {
            return this.order;
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
        /// Method for setting the address from where the client will go
        /// </summary>
        /// <param name="addr">the address from where the client will go that will be assigned</param>
        public void SetAddressOfDeparture(Address addr)
        {
            this.order.AddressOfDeparture = addr;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the address where the client will go
        /// </summary>
        /// <param name="addr">the address where the client will go that will be assigned</param>
        public void SetAddressOfArrival(Address addr)
        {
            this.order.AddressOfArrival = addr;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the time when client wants to go
        /// </summary>
        /// <param name="date">the time when client wants to go that will be assigned</param>
        public void SetTimeOfArrival(DateTime date)
        {
            this.order.TimeOfTheArrivalTaxi = date;
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for setting the class of car that client wants
        /// </summary>
        /// <param name="classOfCar">the class of car that client wants that will be assigned</param>
        public void SetClassOfTaxi(CarClass classOfCar)
        {
            this.order.ClassOfTheTaxi = classOfCar;
        }

    }
}
