using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class SupportDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un nombre")]
        public string NameSupport { get; set; }
        [Required(ErrorMessage = "Favor de llenar el área especificando el problema")]
        public string Issue { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un correo"),EmailAddress(ErrorMessage = "Favor de proporcionar un correo válido")]
        public string EmailSupport { get; set; }
        public string CURP_Support { get; set; }
        public int id_user { get; set; }
        public DateTime AddDate { get; set; }
        public IEnumerable<SelectListItem> IssueTypes { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar un tipo de error")]
        public int id_issue { get; set; }
        public string IssueType { get; set; }
    }
}
