//-----------------------------------------------------------------------
// <copyright file="Helpers.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
namespace UnitTest
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Program;

    /// <summary>
    /// Class with functions and constants for unit-tests
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Symbols allowed for <see cref="Contact.Name"/> property
        /// </summary>
        public static readonly string NameAllowed =
            "QWERTYUIOPASDFGHJKLMNBVCXZ" +
            "qwertyuioplkjhgfdsazxcvbnm";

        /// <summary>
        /// Symbols allowed for <see cref="PhoneContact.Data"/> property
        /// </summary>
        public static readonly string PhoneAllowed = "0123456789";

        /// <summary>
        /// Symbols allowed for <see cref="SkypeContact.Data"/> property
        /// </summary>
        public static readonly string SkypeAllowed = NameAllowed + SkypeAllowed + "_";

        /// <summary>
        /// Minimum length of random-generated string
        /// </summary>
        public static readonly int MinStringLength = 2;

        /// <summary>
        /// Maximum length of random-generated string
        /// </summary>
        public static readonly int MaxStringLength = 13;

        /// <summary>
        /// Standard phone number length
        /// </summary>
        public static readonly int PhoneNumberLength = 10;

        /// <summary>
        /// Minimum domain name length
        /// </summary>
        public static readonly int MinDomainLength = 2;

        /// <summary>
        /// Maximum domain name length
        /// </summary>
        public static readonly int MaxDomainLength = 4;

        /// <summary>
        /// Minimum count of elements in random-generated list
        /// </summary>
        public static readonly int MinListLength = 1;

        /// <summary>
        /// Maximum count of elements in random-generated list
        /// </summary>
        public static readonly int MaxListLength = 10;

        /// <summary>
        /// Object to get random values
        /// </summary>
        public static readonly Random Randomizer = new Random();

        /// <summary>
        /// Array of functions which generate different objects of <see cref="Contact"/> hierarchy 
        /// </summary>
        private static ContactGenerator[] generators = new ContactGenerator[]
        {
            () => 
            {
                return new PhoneContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                GenerateString(PhoneNumberLength, PhoneNumberLength, PhoneAllowed));
            },
            () =>
            {
                string generatedEmail = $"{GenerateString(MinStringLength, MaxStringLength, NameAllowed)}" +
                $"@{GenerateString(MinStringLength, MaxStringLength, NameAllowed)}" +
                $".{GenerateString(MinDomainLength, MaxDomainLength, NameAllowed)}";
                return new MailContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                generatedEmail);
            },
            () =>
            {
                return new SkypeContact(
                GenerateString(MinStringLength, MaxStringLength, NameAllowed),
                GenerateString(MinStringLength, MaxStringLength, SkypeAllowed));
            }
        };

        /// <summary>
        /// Those functions must create and return objects of Contact hierarchy
        /// </summary>
        /// <returns>Newly generated <see cref="Contant"/></returns>
        public delegate Contact ContactGenerator();

        /// <summary>
        /// Generates random string.
        /// Contains not less than <paramref name="minLength"/> and less than <paramref name="maxLength"/> characters.
        /// </summary>
        /// <param name="minLength">Min string length</param>
        /// <param name="maxLength">Max string length (won't be reached)</param>
        /// <param name="source">String which contains all allowed characters (alphabet)</param>
        /// <returns>Newly generated string</returns>
        public static string GenerateString(int minLength, int maxLength, string source)
        {
            StringBuilder toret = new StringBuilder(Randomizer.Next(minLength, maxLength));
            for (int i = 0; i < toret.Capacity; ++i)
            {
                toret.Append(source[Randomizer.Next() % source.Length]);
            }

            return toret.ToString();
        }

        /// <summary>
        /// Generates random <see cref="Contact"/> (any derived type)
        /// </summary>
        /// <returns>Newly generated <see cref="Contact"/></returns>
        public static Contact GenerateContact()
        {
            return generators[Randomizer.Next() % generators.Length]();
        }

        /// <summary>
        /// Generates list of contact. 
        /// Contains not less than <paramref name="minLength"/> and less than <paramref name="maxLength"/> elements.
        /// </summary>
        /// <param name="minLength">Minimum number of objects in list</param>
        /// <param name="maxLength">Maximum number of objects in list (won't be reached)</param>
        /// <returns>Generated <see cref="List{Contact}"/></returns>
        public static List<Contact> GenerateContactList(int minLength, int maxLength)
        {
            int length = Randomizer.Next(minLength, maxLength);
            List<Contact> toret = new List<Contact>();
            for (int i = 0; i < length; ++i)
            {
                toret.Add(GenerateContact());
            }

            return toret;
        }
    }
}
