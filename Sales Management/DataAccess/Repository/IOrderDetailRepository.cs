using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOderDetailByOrderID(int orderID);
        Boolean RemoveOrderDetail(OrderDetail orderDetail);
        Boolean UpdateOrderDetail(OrderDetail orderDetail);
        Boolean AddOrderDetail(OrderDetail orderDetail);
        Boolean AddOrderDetailToList(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetAllOrdersDetailInList();
        Boolean UpdateOrderDetailInList(OrderDetail orderDetail);
        Boolean RemoveOrderDetailInList(OrderDetail orderDetail);
        Boolean AddOrderDetailToDB(IEnumerable<OrderDetail> list);


    }
}
