using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task3
{
    class OrderValidation:IOrderValidation
    {
        public bool ValidateStreet(string street)
        {
            return true;
        }
        
        public bool ValidateHouse(string house)
        {
            return true;
        }
        
        public bool ValidatePorch(string porch)
        {
            return true;
        }
        
        public bool ValidateName(string name)
        {
            Regex regex = new Regex(@"^[A-Za-z]+$");
            return regex.IsMatch(name);
        }
        
        public bool ValidatePhone(string phone)
        {
            Regex regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(phone);
        }
        
        public bool ValidateTime(string time)
        {
            try
            {
                string[] temp = time.Split(':');
                int a = int.Parse(temp[0]);
                int b = int.Parse(temp[1]);
                return (a >= 0 && b >= 0 && a < 24 && b < 60);
            }
            catch
            { return false; }
        }
        
        public bool ValidateDate(string date)
        {
            return true;
        }
    }
}
