using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Favor de ingresar un Usuario")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Favor de ingresar una Contraseña")]
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public int AdminType { get; set; }
        public bool isDeleted { get; set; }
        public bool isUpdate { get; set; }
    }
}
