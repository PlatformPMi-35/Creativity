using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Program
{
    public static class ContactIOManager
    {
        private delegate Contact ContactFactory();

        private static Dictionary<string, ContactFactory> factories = new Dictionary<string, ContactFactory>
        {
            { nameof(PhoneContact), () => { return new PhoneContact(); }  }
        };
        
        public static void Write(Contact contact, StreamWriter stream)
        {
            stream.Write($"{ contact.GetType() } ");
            contact.
        }

        public static Contact Read(Qs);
    }
}
