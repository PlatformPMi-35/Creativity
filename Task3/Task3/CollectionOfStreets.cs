//-----------------------------------------------------------------------
// <copyright file="DatabaseTxt.cs" company="Creativity Team">
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
    /// Represents collection of streets
    /// </summary>
    public class CollectionOfStreets
    {
        /// <summary>
        /// Collections of street
        /// </summary>
        private List<string> streets;

        /// <summary>
        /// / Initializes a new instance of the <see cref = "CollectionOfStreets" /> class.
        /// Сonstructor without parameters
        /// </summary>
        public CollectionOfStreets()
        {
            this.streets = new List<string>();
        }

        /// <summary>
        /// Gets or sets Streets property
        /// </summary>
        public List<string> Streets
        {
            get
            {
                return this.streets;
            }

            set
            {
                this.streets = value;
            }
        }

        /// <summary>
        /// Read collection from file
        /// </summary>
        /// <param name="path">file path</param>
        public void ReadFromFile(string path)
        {
            using (StreamReader stream = new StreamReader(path))
            {
                while (stream.EndOfStream == false)
                {
                    string line = stream.ReadLine();
                    this.streets.Add(line);
                }
            }
        }
    }
}
