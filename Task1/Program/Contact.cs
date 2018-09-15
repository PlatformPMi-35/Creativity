using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Program
{
    /// <summary>
    /// Abstract class, the top of the hierarchy of Contact
    /// </summary>
    public abstract class Contact
    {
        /// <summary>
        /// Represents a name of Contact
        /// </summary>
        private string name;

        /// <summary>
        /// Gets or sets name to Contact
        /// </summary>
        /// <value> The property value must be string and match the template</value>
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
                    throw new ArgumentException("Contact: Warning! "+value);
                }
            }
        }
    }
}
