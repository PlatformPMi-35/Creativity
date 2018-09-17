//-----------------------------------------------------------------------
// <copyright file="ContactExtentions.cs" company="Creativity Team">
// (c) <T> inc.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    /// <summary>
    /// Contains methods to work with Contact hierarchy
    /// </summary>
    public static class ContactExtentions
    {
        /// <summary>
        /// Reads Contacts from file
        /// </summary>
        /// <returns>ArrayList of Contacts</returns>
        public static ArrayList ReadFile()
        {
            ArrayList contacts = new ArrayList();
            string path = "..//..//ContactsInfo.txt";
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    while (!stream.EndOfStream)
                    {
                        try
                        {
                            contacts.Add(ContactIOManager.Read(stream));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return contacts;
        }
    }
}
