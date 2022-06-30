using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetListProducts() => ProductDAO.Instance.GetListProducts();
        public Boolean RemoveProduct(Product p) => ProductDAO.Instance.RemoveProduct(p);
        public Boolean AddProduct(Product p) => ProductDAO.Instance.AddProduct(p);
        public Boolean UpdateProduct(Product p) => ProductDAO.Instance.UpdateProduct(p);

    }
}
