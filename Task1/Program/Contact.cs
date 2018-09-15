//-----------------------------------------------------------------------
// <copyright file="Contact.cs" company="Creativity Team">
// Company copyright tag.
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
                Regex regex = new Regex(@"[A-Z]\D+");
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
        /// Implementation of the interface.
        /// Method for load information from file.
        /// </summary>
        /// <param name="reader">A stream to read information</param>
        public void Read(StreamReader reader)
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
        public void Write(StreamWriter writer)
        {
            writer.WriteLine($"{this.Name}");
        }
    }
}
