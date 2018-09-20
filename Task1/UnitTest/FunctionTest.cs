using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTest
{
    public static class Helpers
    {
        public static readonly string NameAllowed = 
            "QWERTYUIOPASDFGHJKLMNBVCXZ" +
            "qwertyuioplkjhgfdsazxcvbnm";
        public static readonly string PhoneAllowed = "0123456789";
        public static readonly string SkypeAllowed = NameAllowed + SkypeAllowed + "_";
        public static readonly int MinStringLength = 2;
        public static readonly int MaxStringLength = 13;
        public static readonly int PhoneNumberLength = 10;
        public static readonly int MinDomainLength = 2;
        public static readonly int MaxDomainLength = 4;
        public static readonly int MinListLength = 1;
        public static readonly int MaxListLength = 10;
        public static readonly Random random = new Random();
        public delegate Contact ContactGenerator();

        public static ContactGenerator[] generators = new ContactGenerator[]
        {
            () => { return new PhoneContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                GenerateString(PhoneNumberLength, PhoneNumberLength, PhoneAllowed)); },
            () => { return new MailContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                $"{GenerateString(MinStringLength, MaxStringLength, NameAllowed)}" +
                $"@{GenerateString(MinStringLength, MaxStringLength, NameAllowed)}" +
                $".{GenerateString(MinDomainLength, MaxDomainLength, NameAllowed)}");
                },
            () => { return new SkypeContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                GenerateString(MinStringLength, MaxStringLength, SkypeAllowed)); }
        };

        public static string GenerateString(int minLength, int maxLength, string source)
        {
            StringBuilder toret = new StringBuilder(random.Next(minLength, maxLength));
            for (int i = 0; i < toret.Capacity; ++i)
            {
                toret.Append(source[random.Next() % source.Length]);
            }
            return toret.ToString();
        }

        public static Contact GenerateContact()
        {
            return generators[random.Next() % generators.Length]();
        }

        public static List<Contact> GenerateContactList(int minLength, int maxLength)
        {
            int length = random.Next(minLength, maxLength);
            List<Contact> toret = new List<Contact>();
            for (int i = 0; i < length; ++i)
            {
                toret.Add(GenerateContact());
            }
            return toret;
        }
    }

    [TestClass]
    public class ExtensionTest
    {
        public static readonly string filepath = "extensiontestfile.txt";

        public static Contact GenerateContactWithName(string name)
        {
            Contact contact = Helpers.GenerateContact();
            contact.Name = name;
            return contact;
        }

        public static List<Contact> GenerateContactsWithCollidingNames(int minLength, int maxLength)
        {
            List<Contact> toret = new List<Contact>(Helpers.random.Next(minLength, maxLength));
            string name;
            int probabilityDenominator = 3;
            int probabilityNumerator = 2;
            for (int i = 0; i < toret.Capacity;)
            {
                name = Helpers.GenerateString(
                    Helpers.MinStringLength, 
                    Helpers.MaxStringLength,
                    Helpers.NameAllowed);
                toret.Add(GenerateContactWithName(name));
                while (
                    (Helpers.random.Next() % probabilityDenominator) == probabilityNumerator
                    && i < toret.Capacity)
                {
                    toret.Add(GenerateContactWithName(name));
                    ++i;
                }
            }
            return toret;
        }

        [TestMethod]
        public void TestReadFile()
        {
            var contacts = Helpers.GenerateContactList(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            using (StreamWriter stream = new StreamWriter(filepath))
            {
                try
                {
                    foreach (Contact contact in contacts)
                    {
                        ContactIOManager.Write(contact, stream);
                    }
                }
                catch
                {
                    Assert.IsTrue(false);
                }
            }
            ArrayList arrContacts = ContactExtensions.ReadFile(filepath);
            try
            {
                for (int i = 0; i < contacts.Count; ++i)
                {
                    Assert.IsTrue(contacts[i].Equals(arrContacts[i]));
                }
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestSaveSortedContactsToFile()
        {
            var contacts = Helpers.GenerateContactList(
               Helpers.MinListLength,
               Helpers.MaxListLength);
            contacts.Sort((Contact left, Contact right) => 
            {
                return left.Name.CompareTo(right.Name);
            });
            try
            {
                ContactExtensions.SaveSortedContactsToFile(contacts, filepath);
                var arrContacts = ContactExtensions.ReadFile(filepath);
                for (int i = 0; i < contacts.Count; ++i)
                {
                    Assert.IsTrue(contacts[i].Equals(arrContacts[i]));
                }
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestCreatePairsOfContacts()
        {
            var contacts = new ArrayList(GenerateContactsWithCollidingNames(
                Helpers.MinListLength,
                Helpers.MaxListLength));
           
            var dictionary = ContactExtensions.CreatePairsOfContacts(contacts);


        }

        [TestMethod]
        public void TestWriteToFile()
        {
        }

        [TestMethod]
        public void TestSelectAndWriteContactsOnlyWithNumber()
        {
            var contacts = GenerateContactsWithCollidingNames(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            var groups = contacts.GroupBy(contact => contact.Name);
            var uniqueNumberNames = groups
                .Where(grp => grp.Count() == 1 && grp.First() is PhoneContact)
                .Select(grp => grp.First().Name).ToList();
            // ContactExtensions.SelectAndWriteContactsOnlyWithNumber(contacts);

        }

        [TestMethod]
        public void TestSort()
        {
            var contacts = Helpers.GenerateContactList(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            contacts.Sort((Contact left, Contact right) => { return left.Name.CompareTo(right.Name); });
            try
            {
                List<Contact> arrContacts = new List<Contact>(contacts);
                ContactExtensions.Sort(arrContacts);
                for (int i = 0; i < contacts.Count; ++i)
                {
                    Assert.IsTrue(contacts[i].Equals(arrContacts[i]));
                }
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void TestTransformContainerToGeneric()
        {

        }
    }

    [TestClass]
    public class IOManagerTest
    {

        public static readonly string filepath = "iomanagertestfile.txt";


        [TestMethod]
        public void TestReadWrite()
        {
            List<Contact> contacts = Helpers.GenerateContactList(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            using (StreamWriter stream = new StreamWriter(filepath))
            {
                try
                {
                    foreach (Contact contact in contacts)
                    {
                        ContactIOManager.Write(contact, stream);
                    }
                }
                catch
                {
                    Assert.IsTrue(false);
                }
            }
            using (StreamReader stream = new StreamReader(filepath))
            {
                try
                {
                    for (int i = 0; i < contacts.Count; ++i)
                    {
                        Assert.IsTrue(contacts[i].Equals(ContactIOManager.Read(stream)));
                    }
                }
                catch
                {
                    Assert.IsTrue(false);
                }
            }
        }

        [TestMethod]
        public void TestIncorrectReadWrite()
        {
            List<Contact> contacts = Helpers.GenerateContactList(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            using (StreamWriter stream = new StreamWriter(filepath))
            {
                try
                {
                    for (int i = 0; i < contacts.Count / 2; ++i)
                    {
                        ContactIOManager.Write(contacts[i], stream);
                    }
                    stream.WriteLine("BadToken");
                    stream.WriteLine("TokenName");
                    stream.WriteLine("TokenValue");
                    for (int i = contacts.Count / 2 + 1; i < contacts.Count; ++i)
                    {
                        ContactIOManager.Write(contacts[i], stream);
                    }
                }
                catch
                {
                    Assert.IsTrue(false);
                }
            }

            bool isIncorrectValueCatched = false;
            using (StreamReader stream = new StreamReader(filepath))
            {
                try
                {
                    for (int i = 0; i < contacts.Count; ++i)
                    {
                        Assert.IsTrue(contacts[i].Equals(ContactIOManager.Read(stream)));
                    }
                }
                catch (ArgumentException)
                {
                    isIncorrectValueCatched = true;
                }
                catch
                {
                    Assert.IsTrue(false);
                }

                Assert.IsTrue(isIncorrectValueCatched);
            }
        }
    }
}
