using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task3
{
    public enum CarClass
        {
            Economy,
            Comfort,
            Minibus,
            StationWagon,
            Driver
        }
    class Order
    {
        private string nameOfClient;
        private string phoneNumber;
        private Address addressOfDeparture;
        private Address addressOfArrival;
        private DateTime timeOfTheArrivalTaxi;
        private CarClass classOfTheTaxi;
        
        public string NameOfClient
        {
            get
            {
                return nameOfClient;
            }
            set
            {
                Regex regex = new Regex(@"^[A-Za-z]+$");
                if (regex.IsMatch(value))
                {
                    nameOfClient = value;
                }
                else
                {
                    throw new ArgumentException("Name of client: Warning! " + value);
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                Regex regex = new Regex(@"^\d{10}$");
                if (regex.IsMatch(value))
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new ArgumentException("Phone number of client: Warning! " + value);
                }
            }
        }
        public Address AddressOfDeparture
        {
            get
            {
                return addressOfDeparture;
            }
            set
            {
                addressOfDeparture = value;
            }
        }
        public Address AddressOfArrival
        {
            get
            {
                return addressOfArrival;
            }
            set
            {
                addressOfArrival = value;
            }
        }
        public DateTime TimeOfTheArrivalTaxi
        {
            get
            {
                return timeOfTheArrivalTaxi;
            }
            set
            {
                timeOfTheArrivalTaxi = value;
            }
        }
        public CarClass ClassOfTheTaxi
        {
            get
            {
                return classOfTheTaxi;
            }
            set
            {
                classOfTheTaxi = value;
            }
        }
        public Order(string name, string phone, Address dep, Address arr, DateTime arrTime, CarClass classOfCar)
        {
            NameOfClient = name;
            PhoneNumber = phone;
            AddressOfDeparture = dep;
            AddressOfArrival = arr;
            TimeOfTheArrivalTaxi = arrTime;
            ClassOfTheTaxi = classOfCar;
        }
        public void WriteToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(nameOfClient + "; " + phoneNumber + "; "+addressOfDeparture.GetString()+
                    "; "+addressOfArrival.GetString()+ "; " + timeOfTheArrivalTaxi + "; " + classOfTheTaxi);
            
            }
        }
    }
}
