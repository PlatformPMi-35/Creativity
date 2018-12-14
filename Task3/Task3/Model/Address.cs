//-----------------------------------------------------------------------
// <copyright file="Addess.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Represents Address with name of street, house number and porch
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Represents a name of street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Represents a number of house
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Represents a porch in house
        /// </summary>
        public string Porch { get; set; }

        /// <summary>
        /// Represents an id of address
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        ///  Initializes a new instance of the <see cref = "Address" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Address" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="street_">street of this address</param>
        /// <param name="houseNumber_">house number on street of this address</param>
        /// <param name="porch_">porch in house number on street of this address</param>
        public Address(string street_, string houseNumber_, string porch_)
        {
            this.Street = street_;
            this.HouseNumber = houseNumber_;
            this.Porch = porch_;
        }

        
        /// <summary>
        /// Override method, that get the string of address
        /// </summary>
        /// <returns>string of address</returns>
        public override string ToString()
        {
            return this.Street + ";" + this.HouseNumber + ";" + this.Porch;
        }
    }
}
