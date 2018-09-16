using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact contact = new MailContact("Borys", "borys@gmail.com");
            FileInfo stream = new FileInfo("../../file.txt");
            StreamWriter writer = new StreamWriter(stream.Open(FileMode.Truncate));
            ContactIOManager.Write(contact, writer);
            writer.Close();
            StreamReader reader = new StreamReader(stream.Open(FileMode.Open));
            contact = ContactIOManager.Read(reader);
            Console.WriteLine($"Read: {contact}");
            Console.ReadKey();
        }
    }
}
