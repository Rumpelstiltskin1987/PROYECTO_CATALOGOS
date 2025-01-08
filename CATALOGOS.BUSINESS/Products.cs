using DataAccess;
using CATALOGOS.INTERFACES;
using CATALOGOS.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Humanizer.Configuration;
using System.Xml.Linq;

namespace CATALOGOS.BUSINESS
{
    public class BusinessProducts : IProducts
    {
        private readonly MySQLiteContext _contextConnection;
        private readonly CoreProducts _products;
        public BusinessProducts(MySQLiteContext context)
        {
            _contextConnection = context;
            _products = new CoreProducts(_contextConnection);  
        }
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                return _products.GetAllProducts();
            }
            finally
            {
                this._products.Dispose();
            }
        }

        public Product GetProductById(int Id)
        {
            try
            {
                return _products.GetProductById(Id);
            }
            finally
            {
                this._products.Dispose();
            }
        }

        public Product GetByProductName(string name)
        {
            try
            {
                return _products.GetByProductName(name);
            }
            finally
            {
                this._products.Dispose();
            }
        }

        public string AddProduct(Product product)
        {
            try
            {
                return _products.AddProduct(product);
            }
            finally
            {
                this._products.Dispose();
            }
        }

        public string UpdateProduct(Product product)
        {
            try
            {
                return _products.UpdateProduct(product);
            }
            finally
            {
                this._products.Dispose();
            }
        }

        public string DeleteProduct(int Id)
        {
            try
            {
                return _products.DeleteProduct(Id);
            }
            finally
            {
                this._products.Dispose();
            }
        }
    }
}
