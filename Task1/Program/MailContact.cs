//-----------------------------------------------------------------------
// <copyright file="MailContact.cs" company="Creativity Team">
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
    /// Inheritance Contact and containse e-mail in the following format: username@domain.
    /// </summary>
    public class MailContact : Contact, IFileManager
    {
        /// <summary>
        /// Represents a e-mail adress
        /// </summary>
        private string email;

        /// <summary>
        /// Initializes a new instance of the <see cref = "MailContact" /> class.
        /// Constructor without parameters
        /// </summary>
        public MailContact() : base()
        {
            this.email = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "MailContact" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="nameP">Initializes the field of name of base class</param>
        /// <param name="emailP">Initializes the field of email</param>
        public MailContact(string nameP, string emailP) : base(nameP)
        {
            this.Data = emailP;
        }

        /// <summary>
        /// Gets or sets e-mail
        /// </summary>
        /// <value> The property value must be string and match the template</value>
        public override string Data
        {
            get
            {
                return this.email;
            }

            set
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (regex.IsMatch(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("MailContact: Warning! " + value);
                }
            }
        }

        /// <summary>
        /// Implementation of the interface.
        /// Method for load information from file.
        /// </summary>
        /// <param name="reader">A stream to read information</param>
        public override void Read(StreamReader reader)
        {
            base.Read(reader);
            string[] line = reader.ReadLine().Split(' ');
            if (line.Length == 1)
            {
                this.Data = line[0];
            }
        }

        /// <summary>
        /// Implementation of the interface.
        /// Save information in file.
        /// </summary>
        /// <param name="writer">A stream to write information</param>
        public override void Write(StreamWriter writer)
        {
            base.Write(writer);
            writer.WriteLine($"{this.Data}");
        }

        public override bool Equals(object obj)
        {
            if (obj is MailContact)
            {
                return base.Equals(obj) && (obj as Contact).Data == this.Data;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
