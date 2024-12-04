using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }   
        public string UrlImage { get; set; }

    }

    public class ProductList
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
