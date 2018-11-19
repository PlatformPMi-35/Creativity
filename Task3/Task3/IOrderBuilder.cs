using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IOrderBuilder
    {
        IOrderFactory Factory { set; get; }

        Order Build();
        void SetName(string name);
        void SetPhoneNumber(string number);
        void SetAddressOfDeparture(string addr);
        void SetAddressOfArrival(string addr);
        void SetTimeOfArrival(string date);
        void SetClassOfTaxi(string classOfCar);
    }
}
