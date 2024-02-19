using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class SupportBLL
    {
        SupportDAO dao = new SupportDAO();
        public bool AddSupport(SupportDTO support)
        {
            Support s = new Support();

            if (support.ID != 0)
            {
                s.id_user = support.ID;
            }
            s.Name = support.NameSupport;
            s.Email = support.EmailSupport;
            s.CURP = support.CURP_Support;
            s.Issue = support.Issue;
            s.id_IssueType = support.id_issue;
            s.AddDate = DateTime.Now;

            int ID = dao.AddSupport(s);

            if (ID == 0)
            {
                return false;
            }
            else
            {
                LogDAO.AddLog(General.Action.AddSupport, General.Tables.Support, ID, 1);

                string body = string.Format($"Gracias {support.NameSupport} por enviarnos la información de tu problema con el servicio, pronto lo revisaremos y nos pondremos en contacto contigo! <br>Tu ID de seguimiento es el siguiente : {ID} <br>Tu descripción del error : <br>{support.Issue}");

                GMailer mailer = new GMailer();
                mailer.ToEmail = support.EmailSupport;
                mailer.Subject = $"SOPORTE DE CURSOS IPN CASO : {ID}";
                mailer.Body = body;
                mailer.IsHtml = true;
                mailer.Send();

                return true;
            }
            
        }

        public int GetIssueCount()
        {
            return dao.GetIssueCount();
        }

        public IEnumerable<SelectListItem> GetIssueTypes()
        {
            return dao.GetIssueTypes();
        }

        public List<SupportDTO> GetSupportList()
        {
            return dao.GetSupportList();
        }
    }
}
