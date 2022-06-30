using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetListProducts();
        Boolean RemoveProduct(Product p);
        Boolean AddProduct(Product p);
        Boolean UpdateProduct(Product p);

    }
}
