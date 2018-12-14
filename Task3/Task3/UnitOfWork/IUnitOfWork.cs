using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Model;
using Task3.Repository;

namespace Task3.UnitOfWork
{
    public interface IUnitOfWork
    {
        GenericRepository<Address> AddressRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
    }
}
