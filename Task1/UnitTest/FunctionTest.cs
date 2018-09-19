using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;
using System.Text;

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
        public static readonly int MaxStringLength = 12;

        public delegate Contact ContactGenerator();

        public static ContactGenerator[] generators = new ContactGenerator[]
        {
            () => { return new PhoneContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                GenerateString(10, 10, PhoneAllowed)); },
            () => { return new MailContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                $"{GenerateString(MinStringLength, MaxStringLength, NameAllowed)}" +
                $"@{GenerateString(MinStringLength, MaxStringLength, NameAllowed)}" +
                $".{GenerateString(2, 3, NameAllowed)}");
                },
            () => { return new SkypeContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                GenerateString(MinStringLength, MaxStringLength, SkypeAllowed)); }
        };

        public static string GenerateString(int minLength, int maxLength, string source)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            StringBuilder toret = new StringBuilder(minLength + random.Next() % (maxLength - minLength + 1));
            for(int i = 0; i < toret.Capacity; ++i)
            {
                toret[i] = source[random.Next() % source.Length];
            }
            return toret.ToString();
        }

        public static Contact GenerateContact()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            return generators[random.Next() % generators.Length]();
        }
    }

    [TestClass]
    public class ExtensionTest
    {
        [TestMethod]
        public void TestReadFile()
        {
        }

        [TestMethod]
        public void TestSaveSortedContactsToFile()
        {
        }

        [TestMethod]
        public void TestCreatePairsOfContacts()
        {
        }

        [TestMethod]
        public void TestWriteToFile()
        {
        }

        [TestMethod]
        public void TestSelectAndWriteContactsOnlyWithNumber()
        {
        }

        [TestMethod]
        public void TestSort()
        {
        }

        [TestMethod]
        public void TestTransformContainerToGeneric()
        {
        }
    }

    [TestClass]
    public class IOManagerTest
    {
        [TestMethod]
        public void TestRead()
        {
        }

        [TestMethod]
        public void TestWrite()
        {
        }
    }

}
