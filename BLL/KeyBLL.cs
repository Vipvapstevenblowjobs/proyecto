using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KeyBLL
    {
        KeyDAO dao = new KeyDAO();
        public void AddKey(KeyDTO model,int id_Admin)
        {
            Keycard k = new Keycard();
            k.Keycard1 = model.KeyName;
            int ID = dao.AddKey(k);

            LogDAO.AddLog(General.Action.AddKey,General.Tables.Keycard,ID,id_Admin);
        }

        public string DeleteKeycard(int ID,int id_Admin)
        {
            LogDAO.AddLog(General.Action.DeleteKey,General.Tables.Keycard,ID,id_Admin);
            return dao.DeleteKeycard(ID);
        }

        public List<KeyDTO> GetKeycards()
        {
            return dao.GetKeycards();
        }

        public KeyDTO GetKeycardWithID(int ID)
        {
            return dao.GetKeycardsWithID(ID);
        }

        public string UpdateKey(KeyDTO model, int id_Admin)
        {
            LogDAO.AddLog(General.Action.UpdateKeycard,General.Tables.Keycard,model.ID,id_Admin);
            
            return dao.UpdateKey(model);
        }

        public string ViewPDF(int ID)
        {
            return dao.ViewPDF(ID);
        }
    }
}
