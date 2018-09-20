//-----------------------------------------------------------------------
// <copyright file="FILENAME.cs" company="Creativity Team">
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
    [TestClass]
    public class IOManagerTest
    {

        public static readonly string Filepath = "iomanagertestfile.txt";


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

        [TestMethod]
        public void TestIncorrectReadWrite()
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
