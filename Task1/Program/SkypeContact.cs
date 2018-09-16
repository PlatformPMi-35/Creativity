﻿//-----------------------------------------------------------------------
// <copyright file="SkypeContact.cs" company="Creativity Team">
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
    /// Inherits Contact and contains Skype name.
    /// </summary>
    public class SkypeContact : Contact, IFileManager
    {
        /// <summary>
        /// Represents a Skype name
        /// </summary>
        private string skype;

        /// <summary>
        /// Initializes a new instance of the <see cref = "SkypeContact" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public SkypeContact() : base()
        {
            this.skype = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SkypeContact" /> class.
        /// Сonstructor with parameters
        /// </summary>
        /// <param name="nameP">Initializes the field of name of base class</param>
        /// <param name="skypeP">Initializes the field of email</param>
        public SkypeContact(string nameP, string skypeP) : base(nameP)
        {
            this.Skype = skypeP;
        }

        /// <summary>
        /// Gets or sets Skype name
        /// </summary>
        /// <value> The property value must be string and match the template</value>
        private string Skype
        {
            get
            {
                return this.skype;
            }

            set
            {
                Regex regex = new Regex(@"[A-Z]\D+");
                if (regex.IsMatch(value))
                {
                    this.skype = value;
                }
                else
                {
                    throw new ArgumentException("SkypeContact: Warning! " + value);
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
                this.Skype = line[0];
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
            writer.WriteLine($"{this.Skype}");
        }
    }
}
