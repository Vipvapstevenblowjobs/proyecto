using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminBLL
    {
        AdminDAO dao = new AdminDAO();
        public List<CourseDTO> GetAdminInfo()
        {
            return dao.GetCourseTypes();
        }
        public int GetStudentCount()
        {
            return dao.GetStudentCount();
        }
        public int GetMissingStudents()
        {
            return dao.GetMissingStudents();
        }
        public int GroupCount()
        {
            return dao.GroupCount();
        }
        public int GetValidatedStudents()
        {
            return dao.GetValidatedStudents();
        }
        public bool AppointmentMade()
        {
            return dao.AppointmentMade();
        }
        public int SetAppointmentDates(int SC)
        {
            List<StudentDTO> students = dao.GetStudentCountAD();
            int studentCount = students.Count();

            //Temporary value to test the algorithm
            //studentCount = 1000;

            int availableTime = dao.GetTimeCount();
            int availableDays = dao.GetDayCount();
            int availableSchedules = availableDays;
            decimal ratio = studentCount / availableSchedules;

            for (int i = 0; i < availableTime; i++)
            {
                if (ratio < SC)
                {
                    break;
                }
                else
                {
                    availableSchedules += availableDays;
                    ratio = studentCount / availableSchedules;
                }
            }

            int studentsPerSchedule = (int)Decimal.Ceiling(ratio);
            int Day = 1;
            int Time = 1;
            int studs = 0;
            for (int i = 1; i < availableTime+1; i++)
            {
                for (int j = 1; j < availableDays+1; j++)
                {
                    for (int k = 0; k < studentsPerSchedule; k++)
                    {
                        if (studs >= students.Count())
                        {
                            break;
                        }
                        dao.SetAppointment(students[studs].ID, i, j );
                        studs++;
                    }
                    Day++;
                }
                Time++;
            }

            Thread t = new Thread(new ThreadStart(SendAppointmentDates));

            t.Start();

            return availableSchedules;
        }
        public void SendAppointmentDates()
        {
            List<StudentDTO> students = dao.GetStudentsADmade();

            for (int i = 0; i < students.Count(); i++)
            {
                string body = string.Format("Esperamos tengas un excelente día {0} {1} {2} <br> Nos complace informarte que se ha generado tu cita para validar tu registro al {3}! <br>El día {4} a las {5} (En formato de 24 horas) <br>Será un gusto recibirte en el plantel para validar tu registro, recuerda que debes traer lo siguiente : <br>Tu Ficha de Registro <br>Esta es la dirección del plantel , CECyT 9 Juan De Dios Batiz", students[i].Name, students[i].Surname, students[i].Lastname, students[i].CourseName, students[i].AppointmentDay.ToString("dddd dd MMMM yyyy"), students[i].AppointmentTime.ToString(@"hh\:mm"));

                GMailer mailer = new GMailer();
                mailer.ToEmail = students[i].Email;

                mailer.Subject = $"Se ha generado tu cita para validar tu registro al {students[i].CourseName}";
                mailer.Body = body;
                mailer.IsHtml = true;

                mailer.Send();
                
            }
            
        }

        public int GetMessageCount()
        {
            return dao.GetMessageCount();
        }

        public void ModifyCourse(CourseDTO dto,int ID,int id_Admin)
        {
            dao.ModifyCourse(dto);

            LogDAO.AddLog(General.Action.UpdateCourse,General.Tables.Courses,ID,id_Admin);
        }

        public CourseDTO GetCorrectCourse(int ID)
        {
            return dao.GetCorrectCourse(ID);
        }

        public CourseDTO GetCourseInfo()
        {
            return dao.GetCourseInfo();
        }

        public bool AddCourse(CourseDTO model, int id_Admin)
        {
            Course c = new Course();

            c.Course1 = model.CourseType;
            c.id_type = model.TypeID;
            c.id_price = model.PriceID;
            c.id_keycard = model.KeycardID;
            c.Code = model.Code;
            c.vStartDate = model.vStart;
            c.vEndDate = model.vEnd;
            int ID = dao.AddCourse(c);
            if (ID!=0)
            {
                LogDAO.AddLog(General.Action.AddCourse, General.Tables.Courses, ID, id_Admin);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidPrice(int priceID)
        {
            return dao.ValidPrice(priceID);
        }

        public bool ValidType(int typeID)
        {
            return dao.ValidType(typeID);
        }

        public bool ValidKeycard(int keycardID)
        {
            return dao.ValidKeycard(keycardID);
        }
    }
}
