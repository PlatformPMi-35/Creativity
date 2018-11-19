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

        public void AddOrders(Order order)
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
                string[] parse = res[i].Split(' ');
                toret.Add(new Order(parse[0], parse[1], new Address(parse[2], parse[3]), 
                    new Address(parse[4], parse[5]), DateTime.Parse(parse[6]), (CarClass)Enum.Parse(typeof(CarClass),parse[7] )));
            }
            return toret;
        }
    }
}
