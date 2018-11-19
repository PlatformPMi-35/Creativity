using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface IOrderValidation
    {
        bool ValidateStreet(string street);
        bool ValidateHouse(string house);
        bool ValidatePorch(string porch);
        bool ValidateName(string name);
        bool ValidatePhone(string phone);
        bool ValidateTime(string time);
        bool ValidateDate(string date);
    }
}
