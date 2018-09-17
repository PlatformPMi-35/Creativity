﻿using System;
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
            Dictionary<string, List<Contact>> pairs = ContactExtentions.CreatePairsOfContacts(contacts);
            Console.ReadKey();
        }
    }
}
