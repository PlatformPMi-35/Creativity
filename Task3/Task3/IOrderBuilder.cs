using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IOrderBuilder
    {
        void Build();
        Order GetOrder();
        void SetName(string name);
        void SetPhoneNumber(string number);
        void SetAddressOfDeparture(Address addr);
        void SetAddressOfArrival(Address addr);
        void SetTimeOfArrival(DateTime date);
        void SetClassOfTaxi(CarClass classOfCar);
    }
}
