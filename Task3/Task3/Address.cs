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
        private string street;

        /// <summary>
        /// Represents a number of house
        /// </summary>
        private string houseNumber;

        /// <summary>
        /// Represents a porch in house
        /// </summary>
        private string porch;

        /// <summary>
        /// Gets or sets Street property
        /// </summary>
        public string Street
        {
            get
            {
                return street;
            }

            set
            {
                street = value;
            }
        }

        /// <summary>
        /// Gets or sets HouseNumber property
        /// </summary>
        public string HouseNumber
        {
            get
            {
                return houseNumber;
            }

            set
            {
                houseNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets Porch property
        /// </summary>
        public string Porch
        {
            get
            {
                return porch;
            }

            set
            {
                porch = value;
            }
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref = "Address" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public Address() { }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Address" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="street_">street of this address</param>
        /// <param name="houseNumber_">house number on street of this address</param>
        /// <param name="porch_">porch in house number on street of this address</param>
        public Address(string street_, string houseNumber_, string porch_)
        {
            Street = street_;
            HouseNumber = houseNumber_;
            Porch = porch_;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Address" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="street_">street of this address</param>
        /// <param name="houseNumber_">house number on street of this address</param>
        public Address(string street_, string houseNumber_)
        {
            Street = street_;
            HouseNumber = houseNumber_;
        }

        /// <summary>
        /// Override method, that get the string of address
        /// </summary>
        /// <returns>string of address</returns>
        public override string ToString()
        {
            return (street + " " + houseNumber + " " + porch);
            
        }

    }
}
