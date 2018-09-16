//-----------------------------------------------------------------------
// <copyright file="PhoneContact.cs" company="Creativity Team">
// (c) <T> inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Program
{
    /// <summary>
    /// Inheritance Contact and contains phone number as 10-digit string.
    /// </summary>
    public class PhoneContact : Contact, IFileManager
    {
        /// <summary>
        /// Represents a number of PhoneContact
        /// </summary>
        private string number;

        /// <summary>
        /// Initializes a new instance of the <see cref = "PhoneContact" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public PhoneContact() : base()
        {
            this.number = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PhoneContact" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="nameP">Initializes the field of name of base class</param>
        /// <param name="numberP">Initializes the field of number</param>
        public PhoneContact(string nameP, string numberP) : base(nameP)
        {
            this.Number = numberP;
        }

        /// <summary>
        /// Gets or sets number to PhoneContact
        /// </summary>
        /// <value> The property value must be string and match the template</value>
        public string Number
        {
            get
            {
                return this.Number;
            }

            set
            {
                Regex regex = new Regex(@"\d{10}");
                if (regex.IsMatch(value))
                {
                    this.number = value;
                }
                else
                {
                    throw new ArgumentException("PhoneNumber: Warning! " + value);
                }
            }
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for load information from file.
        /// </summary>
        /// <param name="reader">A stream to read information</param>
        override public void Read(StreamReader reader)
        {
            base.Read(reader);
            string[] line = reader.ReadLine().Split(' ');
            if (line.Length == 1)
            {
                this.Number = line[0];
            }
        }

        /// <summary>
        /// Implementation of the interface.
        /// Save information in file.
        /// </summary>
        /// <param name="writer">A stream to write information</param>
        override public void Write(StreamWriter writer)
        {
            base.Write(writer);
            writer.WriteLine($"{this.Number}");
        }
    }
}
