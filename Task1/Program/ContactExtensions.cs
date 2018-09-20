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
    public static class ContactExtensions
    {
        /// <summary>
        /// Reads Contacts from file
        /// </summary>
        /// <returns>ArrayList of <see cref = "Contact" /></returns>
        /// <exception cref="System.Exception">Thrown when invalid input occurs.</exception>
        /// <exception cref="System.IO.IOException">Thrown when an I/O error occurs.</exception>
        public static ArrayList ReadFile(string path)
        {
            ArrayList contacts = new ArrayList();

            using (StreamReader stream = new StreamReader(path))
            {
                while (stream.EndOfStream == false)
                {
                    contacts.Add(ContactIOManager.Read(stream));
                }
            }

            return contacts;
        }
  
        /// <summary>
        /// Saves collection of contacts to file
        /// </summary>
        /// <param name="collection">Collection to save</param>
        public static void SaveSortedContactsToFile(IEnumerable<Contact> collection, string filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                foreach (Contact c in collection)
                {
                    ContactIOManager.Write(c, writer);
                }
            }
        }

        /// <summary>
        /// Create pairs of contacts 
        /// </summary>
        /// <param name="listOfContacts">Contacts which will be written to dictionary</param>
        /// <returns>Dictionary with key - name, and value - phone number, skype name or mail</returns>
        public static Dictionary<string, List<Contact>> CreatePairsOfContacts(ArrayList listOfContacts)
        {
            Dictionary<string, List<Contact>> newPairs = new Dictionary<string, List<Contact>>();
            for (int i = 0; i < listOfContacts.Count; ++i)
            {
                Contact cont = listOfContacts[i] as Contact;
                if (newPairs.ContainsKey(cont.Name) == false)
                {
                    newPairs.Add(cont.Name, new List<Contact> { cont });
                }
                else
                {
                    newPairs[cont.Name].Add(cont);
                }                
            }

            return newPairs;
        }

        /// <summary>
        /// Write contacts to file
        /// </summary>
        /// <param name="pairs">The contact information that will be written to the file</param>
        public static void WriteToFile(Dictionary<string, List<Contact>> pairs, string filepath)
        {
            using (StreamWriter file = new StreamWriter(filepath))
            {
                foreach (var p in pairs)
                {
                    file.Write(p.Key + " - ");
                    foreach (Contact c in p.Value)
                    {
                        file.WriteLine(c.Data + " ");
                    }

                    file.Write(file.NewLine);
                }
            }
        }

        public static List<Contact> SelectContactsOnlyWithNumber(Dictionary<string, List<Contact>> pairs)
        {
            return (from r in pairs
                       where (r.Value.Count == 1 && r.Value[0] is PhoneContact)
                       select r.Value[0]).ToList();
        }

        /// <summary>
        /// Find contacts only with the phone number and write them on the screen
        /// </summary>
        /// <param name="pairs">The contact information that will be used to find contacts only with the phone number</param>
        public static void SelectAndWriteContactsOnlyWithNumber(Dictionary<string, List<Contact>> pairs)
        {
            var cont = SelectContactsOnlyWithNumber(pairs);
            foreach (var c in cont)
            {
                Console.WriteLine(c.Name);
            }
        }

        /// <summary>
        /// Sorts collection of Contacts in lexicographical order by name
        /// </summary>
        /// <param name="collection">Collection to sort</param>
        /// <returns>Sorted collection</returns>
        public static IEnumerable<Contact> Sort(IEnumerable<Contact> collection)
        {
            IEnumerable<Contact> sortedCollection;
            sortedCollection = collection.OrderBy(x => x.Name);
            return sortedCollection;
        }

        /// <summary>
        /// Transforms nongeneric container into generic type
        /// </summary>
        /// <param name="collection">Collection to transform</param>
        /// <returns>Generic collection</returns>
        public static IEnumerable<Contact> TransformContainerToGeneric(IEnumerable collection)
        {
            IEnumerable<Contact> genericCollection;
            genericCollection = collection.OfType<Contact>();
            return genericCollection;
        }
    }
}
