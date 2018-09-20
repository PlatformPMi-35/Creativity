//-----------------------------------------------------------------------
// <copyright file="ExtensionTest.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
namespace UnitTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Program;

    /// <summary>
    /// Test functions from <see cref="ContactExtensions"/>
    /// </summary>
    [TestClass]
    public class ExtensionTest
    {
        /// <summary>
        /// Path to file used by all tests
        /// </summary>
        public static readonly string Filepath = "extensiontestfile.txt";

        /// <summary>
        /// Generates contact with the specified name and random data.
        /// </summary>
        /// <param name="name">property <see cref="Contact.Name"/> will be set to this value</param>
        /// <returns>Generated <see cref="Contact"/></returns>
        public static Contact GenerateContactWithName(string name)
        {
            Contact contact = Helpers.GenerateContact();
            contact.Name = name;
            return contact;
        }

        /// <summary>
        /// Generates list of contact. Some values may have same name.
        /// It is guaranteed that values with the same name are located consequently.
        /// Containce not less than <paramref name="minLength"/> and less than <paramref name="maxLength"/> elements.
        /// </summary>
        /// <param name="minLength">Minimum number of objects in list</param>
        /// <param name="maxLength">Maximum number of objects in list (won't be reached)</param>
        /// <returns>Generated <see cref="List{Contact}"/></returns>
        public static List<Contact> GenerateContactsWithCollidingNames(int minLength, int maxLength)
        {
            List<Contact> toret = new List<Contact>(Helpers.Randomizer.Next(minLength, maxLength));
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
                ++i;
                while (
                  (Helpers.Randomizer.Next() % probabilityDenominator) == probabilityNumerator
                  && i < toret.Capacity)
                {
                    toret.Add(GenerateContactWithName(name));
                    ++i;
                }
            }

            return toret;
        }

        /// <summary>
        /// Tests <see cref="ContactExtensions.ReadFile(string)"/>
        /// </summary>
        [TestMethod]
        public void TestReadFile()
        {
            var contacts = Helpers.GenerateContactList(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            using (StreamWriter stream = new StreamWriter(Filepath))
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

            ArrayList arrContacts = ContactExtensions.ReadFile(Filepath);
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

        /// <summary>
        /// Tests <see cref="ContactExtensions.SaveSortedContactsToFile(IEnumerable{Contact}, string)"/>
        /// </summary>
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
                ContactExtensions.SaveSortedContactsToFile(contacts, Filepath);
                var arrContacts = ContactExtensions.ReadFile(Filepath);
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

        /// <summary>
        /// Tests <see cref="ContactExtensions.CreatePairsOfContacts(ArrayList)"/>
        /// </summary>
        [TestMethod]
        public void TestCreatePairsOfContacts()
        {
            var contacts = GenerateContactsWithCollidingNames(
                Helpers.MinListLength,
                Helpers.MaxListLength);

            var dictionary = ContactExtensions.CreatePairsOfContacts(new ArrayList(contacts));
            int count = 0;
            string name;
            for (int i = 0; i < contacts.Count;)
            {
                name = contacts[i].Name;
                count = 1;
                ++i;
                while (i < contacts.Count)
                {
                    if (name == contacts[i].Name)
                    {
                        ++i;
                        ++count;
                    }
                    else
                    {
                        break;
                    }
                }

                Assert.AreEqual(dictionary[name].Count, count);
            }
        }

        /// <summary>
        /// Tests <see cref="ContactExtensions.SelectContactsOnlyWithNumber(Dictionary{string, List{Contact}})"/>
        /// </summary>
        [TestMethod]
        public void TestSelectContactsOnlyWithNumber()
        {
            var contacts = GenerateContactsWithCollidingNames(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            var groups = contacts.GroupBy(contact => contact.Name);
            var uniqueNumberNames = groups
                .Where(grp => grp.Count() == 1 && grp.First() is PhoneContact)
                .Select(grp => grp.First().Name).ToList();

            var testedContacts = ContactExtensions.SelectContactsOnlyWithNumber(
                ContactExtensions.CreatePairsOfContacts(new ArrayList(contacts)));
            Assert.AreEqual(uniqueNumberNames.Count, testedContacts.Count);
            foreach (var c in uniqueNumberNames)
            {
                Assert.IsTrue(testedContacts.Exists(cont => cont.Name == c));
            }
        }

        /// <summary>
        /// Tests <see cref="ContactExtensions.Sort(IEnumerable{Contact})"/>
        /// </summary>
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

        /// <summary>
        /// Tests <see cref="ContactExtensions.TransformContainerToGeneric(IEnumerable)"/>
        /// </summary>
        [TestMethod]
        public void TestTransformContainerToGeneric()
        {
            List<Contact> contacts = Helpers.GenerateContactList(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            var generic = ContactExtensions.TransformContainerToGeneric(contacts);
            Assert.IsTrue(generic.Count() == contacts.Count);
            int i = 0;
            foreach (object c in generic)
            {
                Assert.IsTrue(c.Equals(contacts[i]));
                ++i;
            }
        }
    }
}
