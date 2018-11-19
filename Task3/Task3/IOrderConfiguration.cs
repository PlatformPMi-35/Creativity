using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface IOrderConfiguration
    {
        IOrderFactory GetFactory();
        IOrderBuilder GetBuilder();
        IOrderValidation GetValidator();
        IDatabaseFacade GetDatabase();
    }
}
