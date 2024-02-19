using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TypeBLL
    {
        TypeDAO dao = new TypeDAO();
        public List<TypeDTO> GetTypes()
        {
            return dao.GetTypes();
        }
    }
}
