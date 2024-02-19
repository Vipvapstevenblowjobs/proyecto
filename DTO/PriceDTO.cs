using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PriceDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un nombre para el esquema de precios"),MinLength(6, ErrorMessage = "Favor de usar al menos 6 caracteres para describir el esquema de precios"),MaxLength(50, ErrorMessage = "Favor de máximo usar 50 caracteres para describir el esquema de precios")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Favor de indicar un precio por curso"),Range(0,10000)]
        public int Course { get; set; }
        [Required(ErrorMessage = "Favor de indicar un precio por curso"), Range(0, 10000)]
        public int Keycard { get; set; }
        [Required(ErrorMessage = "Favor de indicar un precio por curso"),Range(0,10000)]
        public int Notebook { get; set; }
        public bool isUsed { get; set; }
    }
}
