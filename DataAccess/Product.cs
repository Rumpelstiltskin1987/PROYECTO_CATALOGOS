using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Quantity { get; set; }   
        public string UrlImage { get; set; }

        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdateUser { get; set; }  
        public DateTime? UpdateDate { get; set; }    

    }
}
