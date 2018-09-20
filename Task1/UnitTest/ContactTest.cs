//-----------------------------------------------------------------------
// <copyright file="ContactTest.cs" company="Creativity Team">
// (c) <T> inc.
// </copyright>
//-----------------------------------------------------------------------
namespace UnitTest
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Program;

    /// <summary>
    /// Tests methods of contact hierarchy, using polymorphism
    /// </summary>
    [TestClass]
    public class ContactTest
    {
        /// <summary>
        /// Corect input data
        /// </summary>
        [TestMethod]
        public void PropertiesMailContactInputCorrectData()
        {
            Contact mailContact = new MailContact();
            string name = "Vovik";
            string email = "zakalic@gmail.com";
            string exceptionMes = string.Empty;
            try
            {
                mailContact.Name = name;
                mailContact.Data = email;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(mailContact.Name, name);
            Assert.AreEqual(mailContact.Data, email);
            Assert.AreEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Incorrect input data on Name property, expect exception ArgumentException
        /// </summary>
        [TestMethod]
        public void PropertiesMailContactInputIncorrectName()
        {
            Contact mailContact = new MailContact();
            string name = "Vovik19";
            string exceptionMes = string.Empty;
            try
            {
                mailContact.Name = name;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(mailContact.Name, string.Empty);
            Assert.AreNotEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Incorrect input data on Data property, expect exception ArgumentException
        /// </summary>
        [TestMethod]
        public void PropertiesMailContactInputIncorrectEmail()
        {
            Contact mailContact = new MailContact();
            string email = "zakalic@@gmail.com";
            string exceptionMes = string.Empty;
            try
            {
                mailContact.Data = email;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(mailContact.Data, string.Empty);
            Assert.AreNotEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Read correct data from file 
        /// </summary>
        [TestMethod]
        public void ReadMailContact()
        {
            string exceptionMes = string.Empty;
            Contact mailContact = new MailContact();
            Contact standard = new MailContact("Andrii", "internet2wsx@gmail.com");
            StreamReader stream = new StreamReader("../../MailContactInput.txt");
            try
            {
                mailContact.Read(stream);
                stream.Close();
                stream.Dispose();
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(mailContact.Name, standard.Name);
            Assert.AreEqual(mailContact.Data, standard.Data);
            Assert.AreEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Write information about contact to file, save file, read information and compare 
        /// </summary>
        [TestMethod]
        public void WriteMailContact()
        {
            string exceptionMes = string.Empty;
            Contact mailContact = new MailContact();
            Contact standard = new MailContact("Marichka", "mari@yahoo.com");
            StreamWriter streamWriter = new StreamWriter("../../MailContactOutput.txt");
            try
            {
                standard.Write(streamWriter);
                streamWriter.Close();
                streamWriter.Dispose();

                StreamReader streamReader = new StreamReader("../../MailContactOutput.txt");
                mailContact.Read(streamReader);
                streamReader.Close();
                streamReader.Dispose();
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(mailContact.Name, standard.Name);
            Assert.AreEqual(mailContact.Data, standard.Data);
            Assert.AreEqual(exceptionMes, string.Empty);
        }
        
        /// <summary>
        /// Corect input data
        /// </summary>
        [TestMethod]
        public void PropertiesPhoneContactInputCorrectData()
        {
            Contact phoneContact = new PhoneContact();
            string name = "Vovikanidze";
            string phone = "9421235438";
            string exceptionMes = string.Empty;
            try
            {
                phoneContact.Name = name;
                phoneContact.Data = phone;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(phoneContact.Name, name);
            Assert.AreEqual(phoneContact.Data, phone);
            Assert.AreEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Incorrect input data on Name property, expect exception ArgumentException
        /// </summary>
        [TestMethod]
        public void PropertiesPhoneContactInputIncorrectName()
        {
            Contact phoneContact = new PhoneContact();

            // Changed o to 0
            string name = "Kamil0chka";
            string exceptionMes = string.Empty;
            try
            {
                phoneContact.Name = name;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(phoneContact.Name, string.Empty);
            Assert.AreNotEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Incorrect input data on Data property, expect exception ArgumentException
        /// </summary>
        [TestMethod]
        public void PropertiesPhoneContactInputIncorrectNumber()
        {
            Contact phoneContact = new PhoneContact();
            string phone = "12345t6789";
            string exceptionMes = string.Empty;
            try
            {
                phoneContact.Data = phone;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(phoneContact.Data, string.Empty);
            Assert.AreNotEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Read correct data from file 
        /// </summary>
        [TestMethod]
        public void ReadPhoneContact()
        {
            string exceptionMes = string.Empty;
            Contact phoneContact = new PhoneContact();
            Contact standard = new PhoneContact("Zakalic", "1029384756");
            StreamReader stream = new StreamReader("../../PhoneContactInput.txt");
            try
            {
                phoneContact.Read(stream);
                stream.Close();
                stream.Dispose();
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(phoneContact.Name, standard.Name);
            Assert.AreEqual(phoneContact.Data, standard.Data);
            Assert.AreEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Write information about contact to file, save file, read information and compare 
        /// </summary>
        [TestMethod]
        public void WritePhoneContact()
        {
            string exceptionMes = string.Empty;
            Contact phoneContact = new PhoneContact();
            Contact standard = new PhoneContact("Yuriy", "5432167890");
            StreamWriter streamWriter = new StreamWriter("../../PhoneContactOutput.txt");
            try
            {
                standard.Write(streamWriter);
                streamWriter.Close();
                streamWriter.Dispose();

                StreamReader streamReader = new StreamReader("../../PhoneContactOutput.txt");
                phoneContact.Read(streamReader);
                streamReader.Close();
                streamReader.Dispose();
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(phoneContact.Name, standard.Name);
            Assert.AreEqual(phoneContact.Data, standard.Data);
            Assert.AreEqual(exceptionMes, string.Empty);
        }
        
        /// <summary>
        /// Corect input data
        /// </summary>
        [TestMethod]
        public void PropertiesSkypeContactInputCorrectData()
        {
            Contact phoneContact = new SkypeContact();
            string name = "Qwerty";
            string skype = "qwerty_uiop";
            string exceptionMes = string.Empty;
            try
            {
                phoneContact.Name = name;
                phoneContact.Data = skype;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(phoneContact.Name, name);
            Assert.AreEqual(phoneContact.Data, skype);
            Assert.AreEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Incorrect input data on Name property, expect exception ArgumentException
        /// </summary>
        [TestMethod]
        public void PropertiesSkypeContactInputIncorrectName()
        {
            Contact skypeContact = new SkypeContact();
            string name = "Pioner_first";
            string exceptionMes = string.Empty;
            try
            {
                skypeContact.Name = name;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(skypeContact.Name, string.Empty);
            Assert.AreNotEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Incorrect input data on Data property, expect exception ArgumentException
        /// </summary>
        [TestMethod]
        public void PropertiesSkypeContactInputIncorrectSkype()
        {
            Contact skypeContact = new SkypeContact();
            string skype = "MySkype@best";
            string exceptionMes = string.Empty;
            try
            {
                skypeContact.Data = skype;
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(skypeContact.Data, string.Empty);
            Assert.AreNotEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Read correct data from file 
        /// </summary>
        [TestMethod]
        public void ReadSkypeContact()
        {
            string exceptionMes = string.Empty;
            Contact skypeContact = new SkypeContact();
            Contact standard = new SkypeContact("Vasia", "pupkin_vasia1");
            StreamReader stream = new StreamReader("../../SkypeContactInput.txt");
            try
            {
                skypeContact.Read(stream);
                stream.Close();
                stream.Dispose();
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(skypeContact.Name, standard.Name);
            Assert.AreEqual(skypeContact.Data, standard.Data);
            Assert.AreEqual(exceptionMes, string.Empty);
        }

        /// <summary>
        /// Write information about contact to file, save file, read information and compare 
        /// </summary>
        [TestMethod]
        public void WriteSkypeContact()
        {
            string exceptionMes = string.Empty;
            Contact skypeContact = new SkypeContact();
            Contact standard = new SkypeContact("Denchik", "Den4ik_Wi_n_e_r");
            StreamWriter streamWriter = new StreamWriter("../../SkypeContactOutput.txt");
            try
            {
                standard.Write(streamWriter);
                streamWriter.Close();
                streamWriter.Dispose();

                StreamReader streamReader = new StreamReader("../../SkypeContactOutput.txt");
                skypeContact.Read(streamReader);
                streamReader.Close();
                streamReader.Dispose();
            }
            catch (ArgumentException mes)
            {
                exceptionMes = mes.Message;
            }

            Assert.AreEqual(skypeContact.Name, standard.Name);
            Assert.AreEqual(skypeContact.Data, standard.Data);
            Assert.AreEqual(exceptionMes, string.Empty);
        }
    }
}
