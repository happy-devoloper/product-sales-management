using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrdersList();
        IEnumerable<Order> GetOrdersByMemberID(int memberID);
        Boolean RemoveOrder(Order order);
        Boolean UpdateOrder(Order order);
        Boolean CreateOrder(Order order);


    }
}
