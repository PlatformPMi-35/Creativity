using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface IOrderConfiguration
    {
        public IOrderFactory GetFactory();
        public IOrderBuilder GetBuilder();
        public IOrderValidation GetValidator();
        public IDatabaseFacade GetDatabase();
    }
}
