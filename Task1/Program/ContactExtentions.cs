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
                    if (listOfContacts[i] is PhoneContact)
                    {
                        PhoneContact pc = listOfContacts[i] as PhoneContact;
                        newPairs.Add(pc.Name, new List<Contact> { pc });
                    }
                    else if (listOfContacts[i] is SkypeContact)
                    {
                        SkypeContact sc = listOfContacts[i] as SkypeContact;
                        newPairs.Add(sc.Name, new List<Contact> { sc });
                    }
                    else 
                    {
                        MailContact mc = listOfContacts[i] as MailContact;
                        newPairs.Add(mc.Name, new List<Contact> { mc });
                    }
                }
                else
                {
                    if (listOfContacts[i] is PhoneContact)
                    {
                        PhoneContact pc = listOfContacts[i] as PhoneContact;
                        newPairs[pc.Name].Add(pc);
                    }
                    else if (listOfContacts[i] is SkypeContact)
                    {
                        SkypeContact sc = listOfContacts[i] as SkypeContact;
                        newPairs[sc.Name].Add(sc);
                    }
                    else 
                    {
                        MailContact mc = listOfContacts[i] as MailContact;
                        newPairs[mc.Name].Add(mc);
                    }
                }
            }

            return newPairs;
        }

        



    }
}
