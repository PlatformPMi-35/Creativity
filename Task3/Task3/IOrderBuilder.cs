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
        IOrderFactory Factory { set; get; }

        Order Build();
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
        void SetAddressOfDeparture(string addr);
        
        /// <summary>
        /// Method for setting the address where the client will go
        /// </summary>
        /// <param name="addr">the address where the client will go that will be assigned</param>
        void SetAddressOfArrival(string addr);

        /// <summary>
        /// Method for setting the time when client wants to go
        /// </summary>
        /// <param name="date">the time when client wants to go that will be assigned</param>
        void SetTimeOfArrival(string date);

        /// <summary>
        /// Method for setting the class of car that client wants
        /// </summary>
        /// <param name="classOfCar">the class of car that client wants that will be assigned</param>
        void SetClassOfTaxi(string classOfCar);
    }
}
