using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class OrderBuilder : IOrderBuilder
    {
        private IOrderFactory factory;
        public IOrderFactory Factory {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
                order = factory.CreateOrder();
            }
        }

        private Order order;

        public Order Build()
        {
            return order;
        }

        public void SetAddressOfArrival(string addr)
        {
            string[] temp = addr.Split(';');
            order.AddressOfArrival = new Address(temp[0], temp[1], temp[2]);
        }

        public void SetAddressOfDeparture(string addr)
        {
            string[] temp = addr.Split(';');
            order.AddressOfDeparture = new Address(temp[0], temp[1], temp[2]);
        }

        public void SetClassOfTaxi(string classOfCar)
        {
            order.ClassOfTheTaxi= (CarClass)Enum.Parse(typeof(CarClass), classOfCar);
        }

        public void SetName(string name)
        {
            order.NameOfClient = name;
        }

        public void SetPhoneNumber(string number)
        {
            order.PhoneNumber = number;
        }

        public void SetTimeOfArrival(string date)
        {
            order.TimeOfTheArrivalTaxi = DateTime.Parse(date);
        }
    }
}
