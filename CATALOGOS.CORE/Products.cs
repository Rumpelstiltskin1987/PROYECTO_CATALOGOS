using CATALOGOS.INTERFACES;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATALOGOS.CORE
{
    public class CoreProducts : BusinessRules, IProducts
    {
        public CoreProducts(MySQLiteContext context)
            : base(context) 
        {
        }
        public string AddProduct(Product product)
        {
            string message = string.Empty;

            product.CreateUser = "Alpha";
            product.CreateDate = DateTime.Now;

            try
            {
                _contextConnection.Add(product);
                _contextConnection.SaveChangesAsync();
                message = "Producto registrado";
            }
            catch (Exception ex)
            {
                message = "No fue posible registrar el producto: " + ex.Message;
            }
            finally
            {

            }

            return message;
        }

        public string DeleteProduct(int Id)
        {
            string message = string.Empty;

            try
            {
                Product product = new Product();
                
                product = GetProductById(Id);

                _contextConnection.Products.Remove(product);
                _contextConnection.SaveChanges();

                message = "Producto eliminado";
            }
            catch (Exception ex)
            {
                message = "No fue posible eliminar el producto: " + ex.Message;
            }
            finally
            {

            }

            return message;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> productList = new List<Product>();

            try
            {
                productList = _contextConnection.Products.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    UrlImage = p.UrlImage
                }).ToList();
            }
            catch (Exception ex)
            {
                // Aquí puedes registrar el error si es necesario
                Console.WriteLine(ex.Message);
            }

            return productList;
        }


        public Product GetByProductName(string name)
        {
            Product product = new Product();

            try
            {
                product = _contextConnection.Products
                    .Where(x => x.Name == name)
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Quantity = p.Quantity,
                        UrlImage = p.UrlImage
                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return product;
        }

        public Product GetProductById(int Id)
        {
            Product product = new Product();

            try
            {  
                product = _contextConnection.Products
                    .Where(x => x.Id == Id)
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Quantity = p.Quantity,
                        UrlImage = p.UrlImage,
                        CreateUser = p.CreateUser,
                        CreateDate = p.CreateDate,
                        UpdateUser = p.UpdateUser,
                        UpdateDate = !string.IsNullOrEmpty(p.UpdateDate.ToString()) ? p.UpdateDate : null
                    }).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return product;
        }

        public string UpdateProduct(Product product)
        {
            string message = string.Empty;

            product.UpdateUser = "Update";
            product.UpdateDate = DateTime.Now; 

            try
            {
                _contextConnection.Update(product);
                _contextConnection.SaveChangesAsync();
                message = "Producto actualizado";
            }
            catch (Exception ex)
            {
                message = "No fue posible actualizar el producto: " + ex.Message;
            }
            finally
            {

            }

            return message;
        }
    }
}
