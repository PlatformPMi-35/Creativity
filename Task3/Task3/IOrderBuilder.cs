using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents the builder that will create an order
    /// </summary>
    public interface IOrderBuilder
    {
        /// <summary>
        /// Method for creating new order
        /// </summary>
        void Build();

        /// <summary>
        /// Method for getting current order
        /// </summary>
        /// <returns>current order</returns>
        Order GetOrder();

        /// <summary>
        /// Method for setting name of client
        /// </summary>
        /// <param name="name">name that will be assigned</param>
        void SetName(string name);

        /// <summary>
        /// Method for setting phone number of client
        /// </summary>
        /// <param name="number">phone number that will be assigned</param>
        void SetPhoneNumber(string number);

        /// <summary>
        /// Method for setting the address from where the client will go
        /// </summary>
        /// <param name="addr">the address from where the client will go that will be assigned</param>
        void SetAddressOfDeparture(Address addr);

        /// <summary>
        /// Method for setting the address where the client will go
        /// </summary>
        /// <param name="addr">the address where the client will go that will be assigned</param>
        void SetAddressOfArrival(Address addr);

        /// <summary>
        /// Method for setting the time when client wants to go
        /// </summary>
        /// <param name="date">the time when client wants to go that will be assigned</param>
        void SetTimeOfArrival(DateTime date);

        /// <summary>
        /// Method for setting the class of car that client wants
        /// </summary>
        /// <param name="classOfCar">the class of car that client wants that will be assigned</param>
        void SetClassOfTaxi(CarClass classOfCar);
    }
}
