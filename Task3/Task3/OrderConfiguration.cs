using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class OrderConfiguration:IOrderConfiguration
    {
        public IOrderFactory GetFactory()
        {
            return new OrderFactory;
        }
        
        public IOrderBuilder GetBuilder()
        {
            return new OrderBuilder;
        }
        
        public IOrderValidation GetValidator()
        {
            return new OrderValidation;
        }
        
        public IDatabaseFacade GetDatabase()
        {
            return new DatabaseTxt;
        }
    }
}
