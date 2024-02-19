using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddressDTO
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
        public string Municipality { get; set; }
        public string ZipCode { get; set; }
    }
}
