using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DTO
{
    public class GroupDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar el curso al que pertenece el grupo")]
        public int CourseID { get; set; }
        public string Course { get; set; }
        public string Schedule { get; set; }
        public int StudentCount { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar un horario para el grupo")]
        public int ScheduleID { get; set; }
        [Required(ErrorMessage = "Favor de asignar un salón al grupo"), StringLength(2, ErrorMessage = "Favor de proporcionar un salon de 2 digitos"), Range(1, 33, ErrorMessage ="Favor de dar un salón de 1 a 33")]
        public string Classroom { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un nombre para el grupo")]
        public string GroupName { get; set; }
        [Required(ErrorMessage = "Favor de indicar la capacidad del grupo"), Range(20, 100, ErrorMessage = "Favor de proporcionar una capacidad de entre 20 y 100 alumnos")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Favor de indicar el sobrecupo del grupo"),Range(1,20,ErrorMessage = "Favor de proporcionar un sobrecupo de entre 1 y 20 alumnos")]
        public int Overflow { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
        public IEnumerable<SelectListItem> Schedules { get; set; }
    }
}
