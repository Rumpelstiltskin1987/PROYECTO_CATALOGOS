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
        Product GetProductById(int id);
        Product GetByProductName(string name);
        void AddProduct(Product product);
        void UpdateProduct(Product product);  
        void DeleteProduct(Product product);
    }
}
