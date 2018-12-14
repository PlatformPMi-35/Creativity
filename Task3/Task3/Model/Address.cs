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
        /// Represents an id of address
        /// </summary>
        private int id;

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
        /// Initializes a new instance of the <see cref = "Address" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="street_">street of this address</param>
        /// <param name="houseNumber_">house number on street of this address</param>
        public Address(string street_, string houseNumber_)
        {
            this.Street = street_;
            this.HouseNumber = houseNumber_;
        }

        /// <summary>
        /// Gets or sets Id property
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets Street property
        /// </summary>
        public string Street
        {
            get
            {
                return this.street;
            }

            set
            {
                this.street = value;
            }
        }

        /// <summary>
        /// Gets or sets HouseNumber property
        /// </summary>
        public string HouseNumber
        {
            get
            {
                return this.houseNumber;
            }

            set
            {
                this.houseNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets Porch property
        /// </summary>
        public string Porch
        {
            get
            {
                return this.porch;
            }

            set
            {
                this.porch = value;
            }
        }
        
        /// <summary>
        /// Override method, that get the string of address
        /// </summary>
        /// <returns>string of address</returns>
        public override string ToString()
        {
            return this.street + ";" + this.houseNumber + ";" + this.porch;
        }
    }
}
