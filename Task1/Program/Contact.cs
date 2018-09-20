//-----------------------------------------------------------------------
// <copyright file="Contact.cs" company="Creativity Team">
// (c)reativity inc.
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
    /// Abstract class, the top of the hierarchy of Contact
    /// </summary>
    public abstract class Contact : IFileManager
    {
        /// <summary>
        /// Represents a name of <see cref = "Contact" />
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Contact" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public Contact()
        {
            this.name = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Contact" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="nameP">Initializes the field of name</param>
        public Contact(string nameP)
        {
            this.Name = nameP;
        }

        /// <summary>
        /// Gets or sets name to <see cref = "Contact" />
        /// </summary>
        /// <value>The property value must be string and match the template</value>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Regex regex = new Regex(@"^[A-Za-z]+$");
                if (regex.IsMatch(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Contact: Warning! " + value);
                }
            }
        }

        /// <summary>
        /// Gets or sets contact information
        /// </summary>
        public abstract string Data { get; set; }

        /// <summary>
        /// Implementation of the interface.
        /// Method for load information from file.
        /// </summary>
        /// <param name="reader">A stream to read information</param>
        public virtual void Read(StreamReader reader)
        {
            string[] line = reader.ReadLine().Split(' ');
            if (line.Length == 1)
            {
                this.Name = line[0];
            }
        }

        /// <summary>
        /// Implementation of the interface.
        /// Save information in file.
        /// </summary>
        /// <param name="writer">A stream to write information</param>
        public virtual void Write(StreamWriter writer)
        {
            writer.WriteLine($"{this.Name}");
        }

        /// <summary>
        /// Compares two <see cref = "Contact" />s by their names for equality.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>true if objects are equal, false if they're not equal or object is not of type <see cref = "Contact" /></returns>
        public override bool Equals(object obj)
        {
            if (obj is Contact)
            {
                return this.Name.Equals((obj as Contact).Name);
            }

            return false;
        }
        
        /// <summary>
        /// Uses properties <see cref="Name"/> and <see cref="Data"/> to get get hash code.
        /// </summary>
        /// <returns>hash of the object</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Data.GetHashCode();
        }
    }
}
