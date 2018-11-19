using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    public class DatabaseTxt : IDatabaseFacade
    {
        private string filePath;

        public DatabaseTxt(string _filePath)
        {
            filePath = _filePath;
        }

        public void AddOrder(Order order)
        {
            string[] towrite = { order.ToString() };
            File.AppendAllLines(filePath, towrite);
        }

        public List<Order> ReadOrders()
        {
            List<Order> toret = new List<Order>();
            string[] res = File.ReadAllLines(filePath);
            for (int i=0;i<res.Length;++i)
            {
                string[] parse = res[i].Split(';');
                toret.Add(new Order(parse[0], parse[1], new Address(parse[2], parse[3], parse[4]), 
                    new Address(parse[5], parse[6], parse[7]), DateTime.Parse(parse[8]), (CarClass)Enum.Parse(typeof(CarClass),parse[9] )));
            }
            return toret;
        }
    }
}
