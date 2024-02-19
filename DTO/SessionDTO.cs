using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SessionDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string ImagePath { get; set; }
        public int AdminType { get; set; }
    }
}
