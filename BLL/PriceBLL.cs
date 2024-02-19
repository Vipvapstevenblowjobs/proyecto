using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PriceBLL
    {
        PriceDAO dao = new PriceDAO();

        public bool AddPrices(PriceDTO model,int id_Admin)
        {
            int ID = 0;
            bool Success = true;

            Price p = new Price();

            p.PriceName = model.Name;
            p.Notebook_Price = model.Notebook;
            p.Keycard_Price = model.Keycard;
            p.Course_Price = model.Course;

            ID = dao.AddPrices(p);
            if (ID == 0)
            {
                Success = false;
            }
            else
            {
                LogDAO.AddLog(General.Action.AddPrice, General.Tables.Prices, ID, id_Admin);
            }


            return Success;
        }

        public void DeletePrice(int ID,int id_Admin)
        {
            dao.DeletePrices(ID);
            LogDAO.AddLog(General.Action.DeletePrice, General.Tables.Prices, ID, id_Admin);
        }

        public PriceDTO GetCorrectPrice(int ID)
        {
            return dao.GetCorrectPrice(ID);
        }

        public List<PriceDTO> GetPrices()
        {
            return dao.GetPrices();
        }

        public void ModifyPrice(PriceDTO dto, int ID, int id_Admin)
        {
            dao.ModifyPrice(dto);
            LogDAO.AddLog(General.Action.UpdatePrice, General.Tables.Prices, ID, id_Admin);
        }
    }
}
