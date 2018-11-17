using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CollectionOfStreets
    {
        private List<string> streets;

        public CollectionOfStreets()
        {
            streets = new List<string>();
        }

        public List<string> Streets
        {
            get
            {
                return streets;
            }
        }

        public void ReadFromFile(string path)
        {
            using (StreamReader stream = new StreamReader(path))
            {
                while (stream.EndOfStream == false)
                {
                    string line = stream.ReadLine();
                    streets.Add(line);
                }
            }
        }
    }
}
