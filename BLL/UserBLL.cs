using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBLL
    {
        UserDAO dao = new UserDAO();

        public void DeleteUser(int ID, int id_Admin)
        {
            dao.DeleteUser(ID);
            LogDAO.AddLog(General.Action.DeleteAdmin, General.Tables.Users, ID, id_Admin);
        }

        public List<UserDTO> GetAllAdmins()
        {
            return dao.GetAllAdmins();
        }

        public UserDTO GetUserWithID(int ID)
        {
            return dao.GetUserWithID(ID);
        }

        public UserDTO GetUserWithUserNameAndPassword(UserDTO model)
        {
            return dao.GetUserWithUserNameAndPassword(model);
        }

        public bool NewUser(UserDTO model, int id_Admin)
        {
            T_Users u = new T_Users();
            if (model.AdminType == BLL.General.AdminType.regularAdmin)
            {
                u.ImagePath = "AdminUser.jpg";
            }
            else if (model.AdminType == BLL.General.AdminType.AdminUPIS)
            {
                u.ImagePath = "UPIS_AdminUser.jpg";
            }
            else
            {
                u.ImagePath = "UDI_AdminUser.jpg";
            }
            u.username = model.Username;
            u.password = model.Password;
            u.AdminType = model.AdminType;
            LogDAO.AddLog(General.Action.RegisterAdmin,General.Tables.Users,model.ID,id_Admin);
            return dao.NewUser(u);
        }

        public bool UpdateUser(UserDTO model,int id_Admin)
        {
            LogDAO.AddLog(General.Action.UpdateAdmin,General.Tables.Users,model.ID,id_Admin);
            return dao.UpdateUser(model);
        }
    }
}
