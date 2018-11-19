using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Address
    {
        private string street;
        private string houseNumber;
        private string porch;

        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
            }
        }
        public string HouseNumber
        {
            get
            {
                return houseNumber;
            }
            set
            {
                houseNumber = value;
            }
        }
        public string Porch
        {
            get
            {
                return porch;
            }
            set
            {
                porch = value;
            }
        }
        public Address() { }
        public Address(string street_, string houseNumber_, string porch_)
        {
            Street = street_;
            HouseNumber = houseNumber_;
            Porch = porch_;
        }
        public Address(string street_, string houseNumber_)
        {
            Street = street_;
            HouseNumber = houseNumber_;
        }
        public override string ToString()
        {
            return (street + ";" + houseNumber + ";" + porch);
            
        }
    }
}
