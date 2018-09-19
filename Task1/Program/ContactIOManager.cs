//-----------------------------------------------------------------------
// <copyright file="ContactIOManager.cs" company="Creativity Team">
// (c) <T> inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    /// <summary>
    /// Provides convenient input and output for derived Contact classes.
    ///  Any new derived class must be added to 'Factories' field in order to use functions of this class.
    /// </summary>
    public static class ContactIOManager
    {
        /// <summary>
        /// Contains pairs - name of derived Contact class and corresponding function which returns default-constructed object.
        /// Any new derived from Contact class must be added to this dictionary in order to use functions of ContactIOManager
        /// </summary>
        private static readonly Dictionary<string, ContactFactory> Factories 
            = new Dictionary<string, ContactFactory>
        {
            { typeof(PhoneContact).ToString(), () => { return new PhoneContact(); } },
            { typeof(MailContact).ToString(), () => { return new MailContact(); } },
            { typeof(SkypeContact).ToString(), () => { return new SkypeContact(); } }
        };

        /// <summary>
        /// Represents function which returns default-constructed object of Contact hierarchy.
        /// </summary>
        /// <returns>Default-constructed object</returns>
        private delegate Contact ContactFactory();

        /// <summary>
        /// Writes Contact to stream
        /// </summary>
        /// <param name="contact">Contact object which will be written.</param>
        /// <param name="stream">StreamWriter to write to.</param>
        public static void Write(Contact contact, StreamWriter stream)
        {
            stream.WriteLine($"{ contact.GetType().ToString() }");
            contact.Write(stream);
        }

        /// <summary>
        /// Reads Contact from stream 
        /// throws ArgumentException if there is no corresponding derived of Contact.
        /// </summary>
        /// <param name="stream">StramReader to read from.</param>
        /// <returns>Contact which was read</returns>
        public static Contact Read(StreamReader stream)
        {
            string str = stream.ReadLine();
            if (Factories.TryGetValue(str, out ContactFactory factory))
            {
                Contact contact = factory();
                try
                {
                    contact.Read(stream);
                }
                catch
                {
                    throw;
                }

                return contact;
            }
            else
            {
                throw new ArgumentException("Unrecognizable type");
            }
        }
    }
}
