using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public class KeyDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Favor de Indicar el nombre de la credencial"),MinLength(2,ErrorMessage = "Favor de mínimo proporcionar 2 caracteres"),MaxLength(30, ErrorMessage = "Favor de no exceder los 30 caracteres")]
        public string KeyName { get; set; }
        public string Keycard { get; set; }
        [Display(Name = "PDF Creddencial")]
        public HttpPostedFileBase KeycardPDF { get; set; }
        public bool isUsed { get; set; }
        public bool isUpdate { get; set; }
    }
}
