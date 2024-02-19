using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmergencyDTO
    {
        public int ID { get; set; }
        public bool isSik { get; set; }
        public string DaSikness { get; set; }
        public string Treatment { get; set; }
        public string PhoneEmergency { get; set; }
        public string TutorName { get; set; }
        public string PhoneTutor { get; set; }
    }
}
