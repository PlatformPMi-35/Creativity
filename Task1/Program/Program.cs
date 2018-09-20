//-----------------------------------------------------------------------
// <copyright file="ContactIOManager.cs" company="Creativity Team">
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
    /// Contains entry point for application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point for application
        /// </summary>
        /// <param name="args">A list of command line arguments</param>
        public static void Main(string[] args)
        {
            ArrayList contacts = new ArrayList();
            Dictionary<string, List<Contact>> pairs = new Dictionary<string, List<Contact>>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 - Read the contacts from the file in ArrayList;");
                Console.WriteLine("2 - Sort collection in alphabetical order and write it to a File1.txt;");
                Console.WriteLine("3 - Rewrite contacts from ArrayList to the container of pairs and save it in File2.txt;");
                Console.WriteLine("4 - Show the names of people who only have phone number;");
                Console.WriteLine("0 - Вихiд;");
                int choice;
                do
                {
                    Console.Write("\nMake your choice: ");
                }
                while (int.TryParse(Console.ReadLine(), out choice) == false);
                switch (choice)
                {
                    case 1:
                        {
                            contacts = ContactExtentions.ReadFile();
                            Console.WriteLine("The contacts were recorded in ArrayList;");
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        {
                            if (contacts.Count != 0)
                            {
                                var sortedContacts = ContactExtentions.Sort(ContactExtentions.TransformContainerToGeneric(contacts));
                                ContactExtentions.SaveSortedContactsToFile(sortedContacts);
                                Console.WriteLine("The contacts were sorted out and recorded in File1.txt;");
                            }
                            else
                            {
                                Console.WriteLine("ArrayList is empty so it is not possible;");
                            }

                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        {
                            if (contacts.Count != 0)
                            {
                                pairs = ContactExtentions.CreatePairsOfContacts(contacts);
                                ContactExtentions.WriteToFile(pairs);
                                Console.WriteLine("The contacts were rewritten from ArrayList in Dictionary;");
                            }
                            else
                            {
                                Console.WriteLine("ArrayList is empty so it is not possible;");
                            }

                            Console.ReadKey();
                            break;
                        }

                    case 4:
                        {
                            if (contacts.Count != 0)
                            {
                                Console.WriteLine("Names of people who have only phone number:");
                                ContactExtentions.SelectAndWriteContactsOnlyWithNumber(pairs);
                            }
                            else
                            {
                                Console.WriteLine("Firstly rewrite contacts to the container of pairs;");
                            }

                            Console.ReadKey();
                            break;
                        }

                    case 0:
                        {
                            Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Input 1, 2, 3 or 4!");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
    }
}