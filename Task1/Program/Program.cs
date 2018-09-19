using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList contacts = ContactExtentions.ReadFile();
            var sorted = ContactExtentions.Sort(ContactExtentions.TransformContainerToGeneric(contacts));
            Dictionary<string, List<Contact>> pairs = ContactExtentions.CreatePairsOfContacts(contacts);
            ContactExtentions.WriteToFile(pairs);
            ContactExtentions.SelectAndWriteContactsOnlyWithNumber(pairs);
            Console.ReadKey();
        }
    }
}
