using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DTO
{
    public class ScheduleDTO
    {
        public int ID { get; set; }
        public string SchedulePath { get; set; }
        public HttpPostedFileBase ScheduleImage { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un nombre")]
        public string ScheduleName { get; set; }
        public bool isUsed { get; set; }
        public bool isUpdate { get; set; }
    }
}
