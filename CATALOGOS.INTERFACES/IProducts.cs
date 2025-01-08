using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace CATALOGOS.INTERFACES
{
    public interface IProducts
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int Id);
        Product GetByProductName(string name);
        string AddProduct(Product product);
        string UpdateProduct(Product product);
        string DeleteProduct(int Id);
    }
}
