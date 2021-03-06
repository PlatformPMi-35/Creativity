﻿//-----------------------------------------------------------------------
// <copyright file="OrderValidation.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Implementation of the interface
    /// Represents the methods for checking data about order
    /// </summary>
    public class OrderValidation : IOrderValidation
    {
        /// <summary>
        /// Implementation of the interface
        /// Check if string is street
        /// </summary>
        /// <param name="street">name of street</param>
        /// <returns>True if string is correct, false otherwise</returns>
        public bool ValidateStreet(string street)
        {
            return street != string.Empty;
        }

        /// <summary>
        /// Implementation of the interface
        /// Check if string is house
        /// </summary>
        /// <param name="house">number of house</param>
        /// <returns>True if string is correct, false otherwise</returns>
        public bool ValidateHouse(string house)
        {
            return house != string.Empty;
        }

        /// <summary>
        /// Implementation of the interface
        /// Check if string is porch
        /// </summary>
        /// <param name="porch">number of porch</param>
        /// <returns>True if string is correct, false otherwise</returns>
        public bool ValidatePorch(string porch)
        {
            return true;
        }

        /// <summary>
        /// Implementation of the interface
        /// Check if string is name
        /// </summary>
        /// <param name="name">name of person</param>
        /// <returns>True if string is correct, false otherwise</returns>
        public bool ValidateName(string name)
        {
            Regex regex = new Regex(@"^\p{L}+$");
            return regex.IsMatch(name);
        }

        /// <summary>
        /// Implementation of the interface
        /// Check if string is phone number
        /// </summary>
        /// <param name="phone">phone number</param>
        /// <returns>True if string is correct, false otherwise</returns>
        public bool ValidatePhone(string phone)
        {
            Regex regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(phone);
        }

        /// <summary>
        /// Implementation of the interface
        /// Check if string is time
        /// </summary>
        /// <param name="time">time of some event</param>
        /// <returns>True if string is correct, false otherwise</returns>
        public bool ValidateTime(string time)
        {
            try
            {
                string[] temp = time.Split(':');
                int a = int.Parse(temp[0]);
                int b = int.Parse(temp[1]);
                return (a >= 0 && b >= 0 && a < 24 && b < 60);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Implementation of the interface
        /// Check if string is data
        /// </summary>
        /// <param name="date">data of some event</param>
        /// <returns>True if string is correct, false otherwise</returns>
        public bool ValidateDate(string date)
        {
            return true;
        }
    }
}
