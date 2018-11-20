using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents the methods for checking various data
    /// </summary>
    interface IOrderValidation
    {
        /// <summary>
        /// Check if string is street
        /// </summary>
        /// <param name="street">name of street</param>
        /// <returns>True if string is correct, false otherwise</returns>
        bool ValidateStreet(string street);

        /// <summary>
        /// Check if string is house
        /// </summary>
        /// <param name="house">number of house</param>
        /// <returns>True if string is correct, false otherwise</returns>
        bool ValidateHouse(string house);

        /// <summary>
        /// Check if string is porch
        /// </summary>
        /// <param name="porch">number of porch</param>
        /// <returns>True if string is correct, false otherwise</returns>
        bool ValidatePorch(string porch);

        /// <summary>
        /// Check if string is name
        /// </summary>
        /// <param name="name">name of person</param>
        /// <returns>True if string is correct, false otherwise</returns>
        bool ValidateName(string name);

        /// <summary>
        /// Check if string is phone number
        /// </summary>
        /// <param name="phone">phone number</param>
        /// <returns>True if string is correct, false otherwise</returns>
        bool ValidatePhone(string phone);

        /// <summary>
        /// Check if string is time
        /// </summary>
        /// <param name="time">time of some event</param>
        /// <returns>True if string is correct, false otherwise</returns>
        bool ValidateTime(string time);

        /// <summary>
        /// Check if string is data
        /// </summary>
        /// <param name="date">data of some event</param>
        /// <returns>True if string is correct, false otherwise</returns>
        bool ValidateDate(string date);
    }
}
