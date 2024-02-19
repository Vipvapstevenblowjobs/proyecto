using DAL;
using DTO;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ScheduleBLL
    {
        ScheduleDAO dao = new ScheduleDAO();
        public void AddSchedule(ScheduleDTO model, int id_Admin)
        {
            Schedule s = new Schedule();

            s.SchedulePath = model.SchedulePath;

            int ID = dao.AddSchedule(s);
            LogDAO.AddLog(General.Action.AddSchedule,General.Tables.Schedule,ID,id_Admin);
        }

        public string DeleteSchedule(int ID, int id_Admin)
        {
            LogDAO.AddLog(General.Action.DeleteSchedule,General.Tables.Schedule,ID,id_Admin);
            return dao.DeleteSchedule(ID);
        }

        public List<ScheduleDTO> GetSchedules()
        {
            return dao.GetSchedules();
        }

        public ScheduleDTO GetScheduleWithID(int ID)
        {
            return dao.GetScheduleWithID(ID);
        }

        public string ModifySchedule(ScheduleDTO model)
        {
            return dao.ModifySchedule(model);
        }
    }
}
