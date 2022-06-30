using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrdersList() => OrderDAO.Instance.GetOrdersList();
        public IEnumerable<Order> GetOrdersByMemberID(int memberID) => OrderDAO.Instance.GetOrdersByMemberID(memberID);
        public Boolean RemoveOrder(Order order) => OrderDAO.Instance.RemoveOrder(order);
        public Boolean UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
        public Boolean CreateOrder(Order order) => OrderDAO.Instance.CreateOrder(order);

    }
}
