//-----------------------------------------------------------------------
// <copyright file="ContactIOManager.cs" company="Creativity Team">
// (c)reativity inc.
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
        private static readonly string ReadFilePath = "../../ContactsInfo.txt";
        private static readonly string WriteSortedPath = "../../Task1.txt";
        private static readonly string RewritePath = "../../Task2.txt";
        
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
                Console.WriteLine($"1 - Read the contacts from the {ReadFilePath} into ArrayList;");
                Console.WriteLine($"2 - Sort collection in alphabetical order and write it into {WriteSortedPath};");
                Console.WriteLine($"3 - Rewrite contacts from ArrayList to the container of pairs and save it into {RewritePath};");
                Console.WriteLine("4 - Show the names of people who only have phone number;");
                Console.WriteLine("0 - Exit;");
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
                            try
                            {
                                contacts = ContactExtensions.ReadFile(ReadFilePath);
                                Console.WriteLine("The contacts were recorded in ArrayList;");
                            }
                            catch (Exception mes)
                            {
                                Console.WriteLine(mes.Message);
                            }
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        {
                            if (contacts.Count != 0)
                            {
                                try
                                {
                                    var sortedContacts = ContactExtensions.Sort(ContactExtensions.TransformContainerToGeneric(contacts));
                                    ContactExtensions.SaveSortedContactsToFile(sortedContacts, WriteSortedPath);
                                    Console.WriteLine("The contacts were sorted out and recorded in File1.txt;");
                                }
                                catch (Exception mes)
                                {
                                    Console.WriteLine(mes.Message);
                                }
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
                                try {
                                    pairs = ContactExtensions.CreatePairsOfContacts(contacts);
                                    ContactExtensions.WriteToFile(pairs, RewritePath);
                                    Console.WriteLine("The contacts were rewritten from ArrayList in Dictionary;");
                                }
                                catch (Exception mes)
                                {
                                    Console.WriteLine(mes.Message);
                                }
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
                                try
                                {
                                    Console.WriteLine("Names of people who have only phone number:");
                                    ContactExtensions.SelectAndWriteContactsOnlyWithNumber(pairs);
                                }
                                catch (Exception mes)
                                {
                                    Console.WriteLine(mes.Message);
                                }
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