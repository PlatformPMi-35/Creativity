using System;
using Task3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private IOrderValidation validator = new OrderValidation();

        [TestMethod]
        public void CheckValidateCorrectName()
        {
            string name = "Петро";
            Assert.IsTrue(validator.ValidateName(name));
        }

        [TestMethod]
        public void CheckValidateUncorrectName()
        {
            string name = "Петр3о";
            Assert.IsFalse(validator.ValidateName(name));
        }

        [TestMethod]
        public void CheckValidateCorrectPhone()
        {
            string phone = "0987654321";
            Assert.IsTrue(validator.ValidatePhone(phone));
        }

        [TestMethod]
        public void CheckValidateUncorrectPhone()
        {
            string phone = "09876ur0421";
            Assert.IsFalse(validator.ValidatePhone(phone));
        }

        [TestMethod]
        public void CheckValidateCorrectTime()
        {
            string date = "15:35";
            Assert.IsTrue(validator.ValidateTime(date));
        }

        [TestMethod]
        public void CheckValidateUncorrectTime()
        {
            string date = "15:67";
            Assert.IsFalse(validator.ValidateTime(date));
        }

        [TestMethod]
        public void CheckValidateCorrectHouse()
        {
            string house = "56";
            Assert.IsTrue(validator.ValidateHouse(house));
        }

        [TestMethod]
        public void CheckValidateUncorrectHouse()
        {
            string house=string.Empty;
            Assert.IsFalse(validator.ValidateHouse(house));
        }

        [TestMethod]
        public void CheckValidateCorrectStreet()
        {
            string Street = "Soborna";
            Assert.IsTrue(validator.ValidateStreet(Street));
        }

        [TestMethod]
        public void CheckValidateUncorrectStreet()
        {
            string Street = string.Empty;
            Assert.IsFalse(validator.ValidateStreet(Street));
        }

        [TestMethod]
        public void CheckValidateUncorrectPorch()
        {
            string Porch = string.Empty;
            Assert.IsFalse(!validator.ValidatePorch(Porch));
        }
    }
}
