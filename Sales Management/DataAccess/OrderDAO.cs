using BussinessObject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrdersList()
        {
            using var db = new FStoreDBContext();
            var orders = new List<Order>();
            orders = db.Orders.ToList();
            return orders;
        }

        public IEnumerable<Order> GetOrdersByMemberID(int memberID)
        {
            var orders = (List<Order>)GetOrdersList().Where(ord => ord.MemberId == memberID).ToList();
            return orders;
        }

        public Boolean RemoveOrder(Order order)
        {
            using var db = new FStoreDBContext();
            try
            {
                var ord = GetOrdersList().SingleOrDefault(o => o.OrderId == order.OrderId);
                if(ord != null)
                {
                    db.Orders.Remove(ord);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public Boolean UpdateOrder(Order order)
        {
            using var db = new FStoreDBContext();
            try
            {
                var ord = db.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);
                if(ord != null)
                {
                    ord.MemberId = order.MemberId;
                    ord.Freight = order.Freight;
                    db.Orders.Update(ord);
                    if(db.SaveChanges() > 0 )
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean CreateOrder(Order order)
        {
            using var db = new FStoreDBContext();
            try
            {
                var ord = db.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);

                if(ord == null)
                {
                    db.Orders.Add(order);
                    if (db.SaveChanges() > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }


    }
}
