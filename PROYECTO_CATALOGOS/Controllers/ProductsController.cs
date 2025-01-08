using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using CATALOGOS.BUSINESS;

namespace PROYECTO_CATALOGOS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MySQLiteContext _context;
        private readonly BusinessProducts _manageProducts;

        public ProductsController(MySQLiteContext context)
        {
            _context = context;
            _manageProducts = new BusinessProducts(_context);
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> productList = new List<Product>();

            productList = _manageProducts.GetAllProducts();

            return View(productList);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int Id)
        {
            Product product = new Product();

            product = _manageProducts.GetProductById(Id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Quantity,UrlImage")] Product product, IFormFile ProductImage)
        {
            string message = string.Empty;

            message = _manageProducts.AddProduct(product);

            if (ProductImage != null && ProductImage.Length > 0 && message == "Producto registrado")
            {
                // Ruta donde se guardará la imagen
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", ProductImage.FileName);

                // Guardar la imagen en la ruta especificada
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await ProductImage.CopyToAsync(stream);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            Product product = new Product();

            product = _manageProducts.GetProductById(Id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity,UrlImage,CreateUser,CreateDate,UpdateUser,UpdateDate")] Product product, IFormFile ProductImage)
        {
            string message = string.Empty;

            message = _manageProducts.UpdateProduct(product);

            try
            {
                if (ProductImage != null && ProductImage.Length > 0 && message == "Producto actualizado")
                {
                    // Ruta donde se guardará la imagen
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", ProductImage.FileName);

                    // Guardar la imagen en la ruta especificada
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await ProductImage.CopyToAsync(stream);
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    return View(product);
                }
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            Product product = new Product();

            product = _manageProducts.GetProductById(Id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            _manageProducts.DeleteProduct(Id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
