using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class OrderBuilder:IOrderBuilder
    {
        public IOrderFactory factory { get; set; }
        private Order order;

        public void Build()
        {
            factory = new OrderFactory();
            order = factory.CreateOrder();
        }

        public Order GetOrder()
        {
            return order;
        }

        public void SetName(string name)
        {
            order.NameOfClient = name;
        }

        public void SetPhoneNumber(string number)
        {
            order.PhoneNumber = number;
        }

        public void SetAddressOfDeparture(Address addr)
        {
            order.AddressOfDeparture = addr;
        }

        public void SetAddressOfArrival(Address addr)
        {
            order.AddressOfArrival = addr;
        }

        public void SetTimeOfArrival(DateTime date)
        {
            order.TimeOfTheArrivalTaxi = date;
        }

        public void SetClassOfTaxi(CarClass classOfCar)
        {
            order.ClassOfTheTaxi = classOfCar;
        }
    }
}
