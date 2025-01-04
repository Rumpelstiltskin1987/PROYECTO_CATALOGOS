using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class User
    {
        public int Id { get; set; }        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string FirstName { get; set; }        
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string LastName { get; set; }        
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Email { get; set; }        
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }        
        [Required(ErrorMessage = "El numero de teléfono es obligatorio")]
        public string PhoneNumber { get; set; }
    }

    public class UserList
    {
        public List<User> Users = new List<User>(); 
    }
}
