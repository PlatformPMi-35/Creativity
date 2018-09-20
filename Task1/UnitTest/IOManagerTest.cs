//-----------------------------------------------------------------------
// <copyright file="IOManagerTest.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Program;

    /// <summary>
    /// Tests <see cref="ContactIOManager"/> functions
    /// </summary>
    [TestClass]
    public class IOManagerTest
    {
        /// <summary>
        /// Path to the file which is common for all tests
        /// </summary>
        public static readonly string Filepath = "iomanagertestfile.txt";

        /// <summary>
        /// Tests writing data to a file and then retrieving that data back from the same file through reading.
        /// Consequent call of <see cref="ContactIOManager.Write(Contact, StreamWriter)"/> and <see cref="ContactIOManager.Read(StreamReader)"/>
        /// </summary>
        [TestMethod]
        public void TestReadWrite()
        {
            List<Contact> contacts = Helpers.GenerateContactList(
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

            using (StreamReader stream = new StreamReader(Filepath))
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

        /// <summary>
        /// Test behavior of reading incorrect data.
        /// </summary>
        [TestMethod]
        public void TestIncorrectRead()
        {
            List<Contact> contacts = Helpers.GenerateContactList(
                Helpers.MinListLength,
                Helpers.MaxListLength);
            using (StreamWriter stream = new StreamWriter(Filepath))
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
                    for (int i = (contacts.Count / 2) + 1; i < contacts.Count; ++i)
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
            using (StreamReader stream = new StreamReader(Filepath))
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
