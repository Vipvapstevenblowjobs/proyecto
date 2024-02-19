using DAL;
using DTO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static iTextSharp.text.pdf.codec.TiffWriter;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf.parser;

namespace BLL
{
    public class HomeBLL
    {
        HomeDAO dao = new HomeDAO();
        UserDAO userDAO = new UserDAO();
        public StudentDTO GetStudentInfoWithID(int ID)
        {
            StudentDTO student = new StudentDTO();

            student = dao.GetStudentInfoWithID(ID);
            student.Address = dao.GetStudentAddress(student.id_address);
            student.Contact = dao.GetStudentContact(student.id_contact);
            student.Data = dao.GetStudentData(student.id_data);
            student.Emergency = dao.GetStudentEmergency(student.id_emergency);
            student.Course = dao.GetStudentCourseType(student.CourseTypeID);
            student.IssueTypes = dao.GetIssueTypes();
            student.Group = dao.GetStudentGroup(student.id_group);
            student.AppointmentDate = dao.GetStudentAppointmentDate(student.id_date);

            return student;
        }
        public byte[] StudentPDF(int ID, string path)
        {
            StudentDTO student = GetStudentInfoWithID(ID);
            if (student.CourseTypeID == 4)
            {
                using (var existingFileStream = new FileStream(path + "Templates/FICHA_DE_REGISTRO-NS.pdf", FileMode.Open))
                {
                    student.User = userDAO.GetUserWithID(ID);
                    return StampPDF(existingFileStream, student, path);
                }
            }
            else
            {
                using (var existingFileStream = new FileStream(path + "Templates/FICHA_DE_REGISTRO-NMS.pdf", FileMode.Open))
                {
                    student.User = userDAO.GetUserWithID(ID);
                    return StampPDF(existingFileStream, student, path);
                }
            }
        }
        public byte[] StampPDF(FileStream existingFileStream, StudentDTO student, string path)
        {
            using (var output = new MemoryStream())
            {
                var pdfReader = new PdfReader(existingFileStream);

                var stamper = new PdfStamper(pdfReader, output);

                AcroFields field = stamper.AcroFields;

                String fullName = String.Concat($"{student.Data.Name} {student.Data.Surname} {student.Data.Lastname}");

                //  Stamp Student Data

                field.SetField("FullName", fullName);
                field.SetField("Name", student.Data.Name);
                field.SetField("ID", student.ID.ToString());
                field.SetField("AppointmentDate", student.AppointmentDate.ToString("d MMMM yyyy hh mm"));
                field.SetField("CURP", student.Data.CURP);
                field.SetField("BirthDate", student.Data.BirthDate.ToString("d MMMM yyyy"));
                field.SetField("Gender", student.Data.Gender);
                field.SetField("AddDate", student.AddDate.ToString("d MMMM yyyy H mm ss"));

                //  Stamp student Contact Data

                field.SetField("Email", student.Contact.Email);
                field.SetField("Cellphone", student.Contact.Cellphone);

                //Stamp Student Emergency Data

                if (student.Emergency.isSik)
                {
                    field.SetField("isSik", "X");
                    field.SetField("DaSikness", student.Emergency.DaSikness);
                    field.SetField("Treatment", student.Emergency.Treatment);
                }
                field.SetField("Tutor", student.Emergency.TutorName);
                field.SetField("PhoneEmergency", student.Emergency.PhoneEmergency);

                //  Stamp Address information

                field.SetField("Street", student.Address.Street);
                field.SetField("Suburb", student.Address.Suburb);
                field.SetField("Municipality", student.Address.Municipality);

                field.SetField("DaSikness", student.Emergency.DaSikness);
                field.SetField("Treatment", student.Emergency.Treatment);
                field.SetField("EmergencyPhone", student.Emergency.PhoneEmergency);
                field.SetField("RegistryID", student.ID.ToString());

                AcroFields.FieldPosition fieldPosition = stamper.AcroFields.GetFieldPositions("UserImage")[0];

                PushbuttonField imageField = new PushbuttonField(stamper.Writer, fieldPosition.position, "UserImage");
                imageField.Layout = PushbuttonField.LAYOUT_ICON_ONLY;
                imageField.Image = iTextSharp.text.Image.GetInstance(path + "img/UserImages/" + student.User.ImagePath);
                imageField.ScaleIcon = PushbuttonField.SCALE_ICON_ALWAYS;
                imageField.ProportionalIcon = false;
                imageField.Options = BaseField.READ_ONLY;

                stamper.AcroFields.RemoveField("UserImage");
                stamper.AddAnnotation(imageField.Field, fieldPosition.page);

                stamper.FormFlattening = true;
                stamper.Close();
                pdfReader.Close();
                return output.ToArray();
            }
        }
    }
}
