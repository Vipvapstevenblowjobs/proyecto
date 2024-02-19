using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL
{
    public class StudentAdminBLL
    {
        StudentAdminDAO dao = new StudentAdminDAO();
        StudentDAO studentDAO = new StudentDAO();

        public bool CourseIsValid(int ID)
        {
            return dao.CourseIsValid(ID);
        }

        public string DeleteStudent(int ID)
        {
            string path = "";
            StudentDTO student = new StudentDTO();
            student = dao.DeleteStudent(ID);
            dao.DeleteAddress(student.id_address);
            dao.DeleteContact(student.id_contact);
            dao.DeleteData(student.id_data);
            dao.DeleteEmergency(student.id_emergency);
            path = dao.DeleteStudentUser(ID);
            return path;
        }

        public IEnumerable<SelectListItem> GetCourses(int ID)
        {
            return dao.GetCourses(ID);
        }

        public List<StudentDTO> GetStudentList()
        {
            return dao.GetStudentList();
        }

        public StudentDTO GetStudentWithID(int ID)
        {
            return dao.GetStudentWithID(ID);
        }

        public string GetUserImage(int id_user)
        {
            return dao.GetUserImage(id_user);
        }

        public string ModifyStudent(StudentDTO model, int id_Admin)
        {

            //User
            StudentDTO stud = dao.DeleteModifiedUser(model);

            if (stud.isUpdate)
            {
                T_Users u = new T_Users();

                u.username = model.Username;
                u.password = model.Password;
                if (model.ImagePath != null)
                {
                    u.ImagePath = model.ImagePath;
                }
                else
                {
                    u.ImagePath = stud.ImagePath;
                }
                u.AdminType = 0;

                model.id_user = studentDAO.AddUser(u);
            }

            //Address

            if (dao.DeleteModifiedAddress(model))
            {
                Address a = new Address();

                a.Street = model.Street;
                a.Suburb = model.Suburb;
                a.State = model.State;
                a.ZipCode = model.ZipCode;
                a.Municipality = model.Municipality;

                model.id_address = studentDAO.AddAddress(a);
            }

            //Contact

            if (dao.DeleteModifiedContact(model))
            {
                Contact c = new Contact();

                c.Phone = model.Phone;
                c.Cellphone = model.Cellphone;
                c.Email = model.Email;

                model.id_contact = studentDAO.AddContact(c);
            }

            //Data

            if (dao.DeleteModifiedData(model))
            {
                Datum d = new Datum();

                d.Name = model.Name;
                d.Surname = model.Surname;
                d.Lastname = model.Lastname;
                d.CURP = model.CURP;
                d.Birth_Date = model.BirthDate;
                d.Gender = model.Gender;
                d.School = model.School;

                model.id_data = studentDAO.AddData(d);
            }

            //Emergency

            if (dao.DeleteModifiedEmergency(model))
            {
                Emergency e = new Emergency();

                e.isSik = model.isSik;

                if (model.isSik == false)
                {
                    e.DaSik_ness = null;
                    e.treatment = null;
                    e.Phone_emergency = null;
                }
                else
                {
                    e.DaSik_ness = model.DaSikness;
                    e.treatment = model.Treatment;
                    e.Phone_emergency = model.PhoneEmergency;
                }

                e.Tutor = model.TutorName;
                e.Phone_Tutor = model.PhoneTutor;

                model.id_emergency = studentDAO.AddEmergency(e);
            }

            History h = new History();

            h.id_Contact = model.id_contact;
            h.id_Data = model.id_data;
            h.id_User = model.id_user;
            h.id_Address = model.id_address;
            h.id_Emergencies = model.id_emergency;
            h.id_Student = model.ID;

            studentDAO.AddStudentHistory(h);

            LogDAO.AddLog(General.Action.UpdateStudent,General.Tables.Student,model.ID,id_Admin);

            dao.ModifyStudent(model);

            string courseSelected = studentDAO.GetSelectedCourse(model.CourseTypeID);

            string body = string.Format("Tu registro ha sido actualizado con éxito, estos son los nuevos datos de tu cuenta : <br /> Usuario : {0}<br /> Contraseña {1} <br> Email : {2} <br /> Curso Seleccionado : {3} <br /> CURP : {4} <br /> Nombres : {5} {6} {7} <br /> Número de Registro : {8} <br /> Favor de estar al pendiente del resto de la convocatoria para continuar con su pago y validar su INSCRIPCIÓN al Curso.<br />Este correo se genera automáticamente, favor de no responder por este medio. <br />Para cualquier duda o sugerencia usar el siguiente correo: upisbatiz@ipn.mx", model.Username, model.Password, model.Email, courseSelected, model.CURP, model.Name, model.Surname, model.Lastname, model.ID);

            GMailer mailer = new GMailer();
            mailer.ToEmail = model.Email;
            mailer.Subject = $"Actualización de Datos de tu cuenta para el {courseSelected}";
            mailer.Body = body;
            mailer.IsHtml = true;
            mailer.Send();

            return stud.ImagePath;
        }
    }
}
