//-----------------------------------------------------------------------
// <copyright file="ContactTest.cs" company="Creativity Team">
// (c) <T> inc.
// </copyright>
//-----------------------------------------------------------------------
namespace UnitTest
{
    using Program;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests methods of contact hierarchy
    /// </summary>
    [TestClass]
    public class ContactTest
    {

        /// <summary>
        /// Conveniet function to write string data to file. 
        /// Usually used to write data right before reading it in test methods.
        /// Doesn't close file given.
        /// </summary>
        /// <param name="file">FileStream to write to.</param>
        /// <param name="args">String arguments which will be written.</param>
        private static void WriteData (FileStream file, string[] args)
        {
            StreamWriter writer = new StreamWriter(file);
            for(int i = 0; i < args.Length; ++i)
            {
                writer.WriteLine(args[i]);
            }
        }

        /// <summary>
        /// Tries to read given contact from file. Any exception will be caught.
        /// Doesn't close file given.
        /// </summary>
        /// <param name="file">FileStream to read from.</param>
        /// <param name="contact">Contact to read</param>
        /// <returns>Whether reading was successful (no exception occured)</returns>
        private static bool TryRead (FileStream file, Contact contact)
        {
            bool succeded = true;
            StreamReader reader = new StreamReader(file);
            try
            {
                contact.Read(reader);
            }
            catch
            {
                succeded = false;
            }
            return succeded;
        }

        /// <summary>
        /// Creates new FileStream. Also creates new file in current unit test project directory, if needed.
        /// </summary>
        /// <param name="name">Extension-qualified file name</param>
        /// <returns>Newly created FileStream instance</returns>
        private static FileStream CreateReadWriteFileStream(string name)
        {
            return new FileStream(name, FileMode.Create);
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadCorrectPhoneContact()
        {
            
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadCorrectMailContact()
        {

        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadCorrectSkypeContact()
        {
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadIncorrectPhoneContact()
        {
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadIncorrectMailContact()
        {
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadIncorrectSkypeContact()
        {
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadIncorrectPhoneContactName()
        {
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadIncorrectMailContactName()
        {
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void ReadIncorrectSkypeContactName()
        {
        }
    }
}
