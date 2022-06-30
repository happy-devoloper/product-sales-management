using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetOderDetailByOrderID(int orderID) => OrderDetailDAO.Instance.GetOderDetailByOrderID(orderID);
        public Boolean RemoveOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.RemoveOrderDetail(orderDetail);
        public Boolean UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
        public Boolean AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail);
        public Boolean AddOrderDetailToList(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetailToList(orderDetail);
        public IEnumerable<OrderDetail> GetAllOrdersDetailInList() => OrderDetailDAO.Instance.OrderDetailsList;
        public Boolean UpdateOrderDetailInList(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetailInList(orderDetail);
        public Boolean RemoveOrderDetailInList(OrderDetail orderDetail) => OrderDetailDAO.Instance.RemoveOrderDetailInList(orderDetail);
        public Boolean AddOrderDetailToDB(IEnumerable<OrderDetail> list) => OrderDetailDAO.Instance.AddOrderDetailToDB(list);


    }
}
