using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        private static List<OrderDetail> orderDetail = new List<OrderDetail>();

        private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetListOrderDetail()
        {
            using var db = new FStoreDBContext();
            var odersDetail = new List<OrderDetail>();
            odersDetail = db.OrderDetails.ToList();
            return odersDetail;
        }

        public IEnumerable<OrderDetail> GetOderDetailByOrderID(int orderID)
        {
            using var db = new FStoreDBContext();
            var odersDetail = new List<OrderDetail>();
            odersDetail = db.OrderDetails.Where(ordDetail => ordDetail.OrderId == orderID).ToList();
            return odersDetail;
        }

        public Boolean RemoveOrderDetail(OrderDetail orderDetail)
        {
            using var db = new FStoreDBContext();
            try
            {
                var product = db.Products.SingleOrDefault(pro => pro.ProductId == orderDetail.ProductId);
                product.UnitsInStock += orderDetail.Quantity;

                db.OrderDetails.Remove(orderDetail);
                db.Products.Update(product);

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean UpdateOrderDetail(OrderDetail orderDetail)
        {
            using var db = new FStoreDBContext();
            try
            {
                var product = db.Products.SingleOrDefault(pro => pro.ProductId == orderDetail.ProductId);
                var oldOrderDetail = GetListOrderDetail().SingleOrDefault(ord => (ord.ProductId == orderDetail.ProductId && ord.OrderId == orderDetail.OrderId));

                if (product == null)
                {
                    throw new Exception("Product does NOT exist!!");
                }
                else if (orderDetail.Quantity <= 0 || orderDetail.Discount < 0)
                {
                    throw new Exception("The Number must be POSITVE!!");
                }
                else if (product.UnitsInStock < orderDetail.Quantity)
                {
                    throw new Exception("Not enough Quantity for Product!!");
                }
                else if (orderDetail.Discount > 100)
                {
                    throw new Exception("Discount must be [0-100]%");
                }
                else
                {
                    int quantity = 0;
                    if (oldOrderDetail != null)
                    {
                        //Update unit stock
                        quantity = oldOrderDetail.Quantity - orderDetail.Quantity;
                        product.UnitsInStock += quantity;
                    }

                    db.OrderDetails.Update(orderDetail);
                    db.Products.Update(product);

                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Boolean AddOrderDetail(OrderDetail orderDetail)
        {
            using var db = new FStoreDBContext();
            try
            {
                var product = db.Products.SingleOrDefault(pro => pro.ProductId == orderDetail.ProductId);
                var oldOrderDetail = GetListOrderDetail().SingleOrDefault(ord => (ord.ProductId == orderDetail.ProductId && ord.OrderId == orderDetail.OrderId));

                if (product == null)
                {
                    throw new Exception("Product does NOT exist!!");
                }
                else if (orderDetail.Quantity < 0 || orderDetail.Discount < 0)
                {
                    throw new Exception("The Number must be POSITVE!!");
                }
                else if (orderDetail.Quantity == 0)
                {
                    throw new Exception("The Quantity can NOT 0!!");
                }
                else if (product.UnitsInStock < orderDetail.Quantity)
                {
                    throw new Exception("Not enough Quantity for Product!!");
                }
                else if (orderDetail.Discount > 100)
                {
                    throw new Exception("Discount must be [0-100]%");
                }
                else if (oldOrderDetail != null)
                {
                    throw new Exception("This Product has already EXIST!!");
                }
                else
                {

                    //Update unit stock                      
                    product.UnitsInStock -= orderDetail.Quantity;

                    db.OrderDetails.Add(orderDetail);
                    db.Products.Update(product);

                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<OrderDetail> OrderDetailsList => orderDetail;

        public Boolean AddOrderDetailToList(OrderDetail orderDetail)
        {
            using var db = new FStoreDBContext();
            List<OrderDetail> ordDetail = new List<OrderDetail>();
            try
            {
                var product = db.Products.SingleOrDefault(pro => pro.ProductId == orderDetail.ProductId);
                var detail = OrderDetailsList.SingleOrDefault(detail => detail.ProductId == orderDetail.ProductId);

                if (detail != null)
                {
                    throw new Exception("This Product has already exist!!");
                }
                else if (product == null)
                {
                    throw new Exception("Product does NOT exist!!");
                }
                else if (orderDetail.Quantity < 0 || orderDetail.Discount < 0)
                {
                    throw new Exception("The Number must be POSITVE!!");
                }
                else if (orderDetail.Quantity == 0)
                {
                    throw new Exception("The Quantity can NOT 0!!");
                }
                else if (product.UnitsInStock < orderDetail.Quantity)
                {
                    throw new Exception("Not enough Quantity for Product!!");
                }
                else if (orderDetail.Discount > 100)
                {
                    throw new Exception("Discount must be [0-100]%");
                }
                else
                {

                    //Update unit stock                      
                    product.UnitsInStock -= orderDetail.Quantity;
                    db.Products.Update(product);
                    db.SaveChanges();

                    OrderDetailsList.Add(orderDetail);
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean UpdateOrderDetailInList(OrderDetail orderDetail)
        {
            using var db = new FStoreDBContext();
            try
            {
                var product = db.Products.SingleOrDefault(pro => pro.ProductId == orderDetail.ProductId);
                var oldOrderDetail = OrderDetailsList.SingleOrDefault(ord => (ord.ProductId == orderDetail.ProductId && ord.OrderId == orderDetail.OrderId));

                if (product == null)
                {
                    throw new Exception("Product does NOT exist!!");
                }
                else if (orderDetail.Quantity <= 0 || orderDetail.Discount < 0)
                {
                    throw new Exception("The Number must be POSITVE!!");
                }
                else if (product.UnitsInStock < orderDetail.Quantity)
                {
                    throw new Exception("Not enough Quantity for Product!!");
                }
                else if (orderDetail.Discount > 100)
                {
                    throw new Exception("Discount must be [0-100]%");
                }
                else
                {
                    int quantity = 0;
                    if (oldOrderDetail != null)
                    {
                        //Update unit stock
                        quantity = oldOrderDetail.Quantity - orderDetail.Quantity;
                        product.UnitsInStock += quantity;
                    }
                    

                    db.Products.Update(product);

                    if (db.SaveChanges() > 0)
                    {
                        var index = OrderDetailsList.IndexOf(oldOrderDetail);
                        OrderDetailsList[index] = orderDetail;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean RemoveOrderDetailInList(OrderDetail orderDetail)
        {
            using var db = new FStoreDBContext();
            try
            {
                var product = db.Products.SingleOrDefault(pro => pro.ProductId == orderDetail.ProductId);
                product.UnitsInStock += orderDetail.Quantity;

                OrderDetailsList.Remove(orderDetail);

                db.Products.Update(product);

                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean AddOrderDetailToDB(IEnumerable<OrderDetail> list)
        {
            try
            {
                using var db = new FStoreDBContext();
                db.OrderDetails.AddRange(list);
                if (db.SaveChanges() > 0)
                {
                    orderDetail = new List<OrderDetail>();
                    return true;
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            orderDetail = new List<OrderDetail>();
            return false;
        }

    }
}
