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
    public class StudentBLL
    {
        StudentDAO dao = new StudentDAO();

        public IEnumerable<SelectListItem> GetCourseTypesAvailable(int ID)
        {
            return dao.GetCourseTypesAvailable(ID);
        }

        public void RegisterStudent(StudentDTO model)
        {
            Student student = new Student();
            Datum data = new Datum();
            Emergency emergency = new Emergency();
            Contact contact = new Contact();
            Address address = new Address();
            T_Users user = new T_Users();

            //Data

            data.Name = model.Name;
            data.Surname = model.Surname;
            data.Lastname = model.Lastname;
            data.CURP = model.CURP;
            data.Birth_Date = model.BirthDate;
            data.Gender = model.Gender;
            data.School = model.School;

            student.id_data = dao.AddData(data);

            //Emergency

            emergency.isSik = model.isSik;
            emergency.DaSik_ness = model.DaSikness;
            emergency.treatment = model.Treatment;
            emergency.Phone_emergency = model.PhoneEmergency;
            emergency.Tutor = model.TutorName;
            emergency.Phone_Tutor = model.PhoneTutor;

            student.id_emergency = dao.AddEmergency(emergency);

            //Address

            address.Street = model.Street;
            address.State = model.State;
            address.Suburb = model.Suburb;
            address.Municipality = model.Municipality;
            address.ZipCode = model.ZipCode;

            student.id_address = dao.AddAddress(address);

            //Contact

            contact.Cellphone = model.Cellphone;
            contact.Phone = model.Phone;
            contact.Email = model.Email;

            student.id_contact = dao.AddContact(contact);

            student.id_course = model.CourseTypeID;

            //User

            user.username = model.Username;
            user.password = model.Password;
            user.ImagePath = model.ImagePath;
            user.AdminType = 0;

            student.id_user = dao.AddUser(user);

            student.AddDate = DateTime.Now;

            if (student.id_address != 0 && student.id_contact != 0 && student.id_data != 0 && student.id_emergency != 0 && student.id_user != 0)
            {
                int studentID = dao.AddStudent(student);

                History history = new History();
                history.id_Address = student.id_address;
                history.id_Contact = student.id_contact;
                history.id_Data = student.id_data;
                history.id_Emergencies = student.id_emergency;
                history.id_User = student.id_user;
                history.id_Student = studentID;
                history.id_Course = student.id_course;

                dao.AddStudentHistory(history);

                string courseSelected =  dao.GetSelectedCourse(model.CourseTypeID);

                string body = string.Format("Registro exitoso de tu cuenta con los siguientes datos : <br /> Usuario : {0}<br /> Contraseña {1} <br> Email : {2} <br /> Curso Seleccionado : {3} <br /> CURP : {4} <br /> Nombres : {5} {6} {7} <br /> Número de Registro : {8} <br /> Favor de estar al pendiente del resto de la convocatoria para continuar con su pago y validar su INSCRIPCIÓN al Curso.<br />Este correo se genera automáticamente, favor de no responder por este medio. <br />Para cualquier duda o sugerencia usar el siguiente correo: upisbatiz@ipn.mx", model.Username,model.Password,model.Email,courseSelected,model.CURP,model.Name,model.Surname,model.Lastname,studentID);

                GMailer mailer = new GMailer();
                mailer.ToEmail = model.Email;
                mailer.Subject = $"Registro exitoso al {courseSelected}";
                mailer.Body = body;
                mailer.IsHtml = true;
                mailer.Send();
            }
            else
            {
                dao.failedToRegister(address,contact,data,emergency,user, student.id_address, student.id_contact, student.id_data, student.id_emergency, student.id_user);
            }
        }

        public int ValidUser(StudentDTO model)
        {
            return dao.ValidUser(model);
        }
    }
}
