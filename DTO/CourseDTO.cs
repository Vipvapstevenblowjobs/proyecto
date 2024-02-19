using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class CourseDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar un tipo de curso")]
        public int TypeID { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar una credencial para el curso")]
        public int KeycardID { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar un esquema de precios para el curso")]
        public int PriceID { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> Keycards { get; set; }
        public IEnumerable<SelectListItem> Prices { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un nombre para el curso")]
        public string CourseType { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un código el curso")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar una fecha de inicio para el registro")]
        public DateTime vStart { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar una fecha límite para el registro")]
        public DateTime vEnd { get; set; }
        public bool Valid { get; set; }
    }
}
