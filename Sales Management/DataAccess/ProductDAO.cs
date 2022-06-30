using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetListProducts()
        {
            using var db = new FStoreDBContext();
            try
            {
                var products = db.Products.ToList();
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("Get List Products");
            }
        }

        public Boolean RemoveProduct(Product p)
        {
            using var db = new FStoreDBContext();
            try
            {
                Product product = GetListProducts().SingleOrDefault(pro => pro.ProductId == p.ProductId);
                if (product != null)
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Remove failed!");
            }
            return false;
        }

        public Boolean AddProduct(Product p)
        {
            using var db = new FStoreDBContext();
            try
            {
                Product product = GetListProducts().SingleOrDefault(pro => pro.ProductId == p.ProductId);
                var category = db.Categories.SingleOrDefault(cate => cate.CategoryId == p.CategoryId);


                if (product != null)
                {
                    throw new Exception("This product has already exist!!");
                }
                else if (category == null)
                {
                    throw new Exception("Category does not exist!!");
                }
                else if (p.UnitPrice < 0)
                {
                    throw new Exception("Unit Price must be a Positive Number!!");
                } 
                else if (p.ProductId < 0)
                {
                    throw new Exception("Product ID must be a Positive Number!!");
                }
                else if (p.ProductName == "" || p.Weight == "")
                {
                    throw new Exception("Fields can NOT be EMPTY!!");
                }
                else
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean UpdateProduct(Product p)
        {
            using var db = new FStoreDBContext();
            try
            {
                var category = db.Categories.SingleOrDefault(cate => cate.CategoryId == p.CategoryId);

                if (category == null)
                {
                    throw new Exception("Category does not exist!!");
                }
                else if (p.UnitPrice < 0)
                {
                    throw new Exception("Unit Price must be a Positive Number!!");
                }
                else if (p.ProductId < 0)
                {
                    throw new Exception("Product ID must be a Positive Number!!");
                }
                else if (p.ProductName == "" || p.Weight == "")
                {
                    throw new Exception("Fields can NOT be EMPTY!!");
                }
                else
                {
                    db.Products.Update(p);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
