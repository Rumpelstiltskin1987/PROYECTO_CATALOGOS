using DataAccess;
using CATALOGOS.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Humanizer.Configuration;

namespace CATALOGOS.BUSINESS
{
    public class Products : IProducts
    {
        private readonly MySQLiteContext _context;
        public Products(MySQLiteContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> productList = new List<Product>();

            try
            {
                productList = _context.Products.ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return productList;
        }

        public Product GetProductById(int id)
        {
            return new Product();
        }

        public Product GetByProductName(string name)
        {
            return new Product();
        }

        void IProducts.AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        void IProducts.UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        void IProducts.DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
