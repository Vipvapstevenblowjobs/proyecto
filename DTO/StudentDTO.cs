using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DTO
{
    public class StudentDTO
    {
        //STUDENT
        public int ID { get; set; }
        [Display(Name = "User Image")]
        public HttpPostedFileBase UserImage { get; set; }
        public int id_user { get; set; }
        public int id_address { get; set; }
        public int id_contact { get; set; }
        public int id_emergency { get; set; }
        public int id_data { get; set; }
        public int id_issue { get; set; }
        public int id_group { get; set; }
        public int id_date { get; set; }
        public bool ValidSession { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public DateTime AppointmentDay { get; set; }
        public bool isValidated { get; set; }
        public bool Accepts { get; set; }
        public bool isUpdate { get; set; }
        //User
        public UserDTO User { get; set; }

        //public int ID { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un nombre de usuario"),MinLength(6,ErrorMessage = "Tu nombre de usuario debe ser de entre 6 y 50 caracteres"), MaxLength(50,ErrorMessage = "Tu nombre de usuario debe ser de entre 6 y 50 caracteres")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar una contraseña"), MinLength(8, ErrorMessage = "Tu contraseña debe tener entre 8 y 50 caracteres"), MaxLength(50, ErrorMessage = "Tu contraseña debe tener entre 8 y 50 caracteres")]
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public bool isDeleted { get; set; }
        public string ImagePath { get; set; }

        //Emergencies
        public EmergencyDTO Emergency { get; set; }
        public bool isSik { get; set; }
        [MaxLength(100,ErrorMessage = "Favor de usar menos de 100 caracteres para describir la enfermedad padecida")]
        public string DaSikness { get; set; }
        public string Treatment { get; set; }
        [MaxLength(10, ErrorMessage = "Introduce un número de 10 dígitos")]
        public string PhoneEmergency { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un nombre de Tutor"), MinLength(6, ErrorMessage = "El nombre de tu tutor debe ser de entre 6 y 50 caracteres"), MaxLength(50, ErrorMessage = "El nombre de tu tutor debe ser de entre 6 y 50 caracteres")]
        public string TutorName { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar el teléfono de tu Tutor"), MaxLength(11, ErrorMessage = "Introduce un número de entre 8 y 10 dígitos"), MinLength(10, ErrorMessage = "Introduce un número de  10 dígitos")]
        public string PhoneTutor { get; set; }

        //Contact
        public ContactDTO Contact { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un numero de contacto"), MaxLength(11, ErrorMessage = "Introduce un número de entre 8 y 10 dígitos"), MinLength(10, ErrorMessage = "Introduce un número de  10 dígitos")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un celuar"), MaxLength(11, ErrorMessage = "Introduce un número de  10 dígitos"), MinLength(10, ErrorMessage = "Introduce un número de  10 dígitos")]
        public string Cellphone { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un correo"), EmailAddress(ErrorMessage = "Favor de proporcionar un correo válido"),MaxLength(50,ErrorMessage = "Tu correo debe ser máximo de 50 caracteres")]
        public string Email { get; set; }

        //Address
        public AddressDTO Address { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu calle"), MinLength(6, ErrorMessage = "Favor de usar al menos 6 caracteres para describir tu calle"), MaxLength(50, ErrorMessage = "Favor de no usar más de 100 caracteres para describir tu calle")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu Estado"), MinLength(4, ErrorMessage = "Favor de usar al menos 6 caracteres para describir tu Estado"), MaxLength(50, ErrorMessage = "Favor de no usar más de 100 caracteres para describir tu Estado")]
        public string State { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu Colonia"), MinLength(4, ErrorMessage = "Favor de usar al menos 4 caracteres para describir tu Colonia"), MaxLength(50, ErrorMessage = "Favor de no usar más de 100 caracteres para describir tu Colonia")]
        public string Suburb { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu Municipio (Delegación)"), MinLength(5, ErrorMessage = "Favor de usar al menos 5 caracteres para describir tu Municipio"), MaxLength(50, ErrorMessage = "Favor de no usar más de 100 caracteres para describir tu Municipio")]
        public string Municipality { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar un Código Postal"), MaxLength(6, ErrorMessage = "Favor de proporcionar un Codigo Postal Válido"), MinLength(5, ErrorMessage = "Favor de proporcionar un CP Valido")]
        public string ZipCode { get; set; }

        //Data
        public DataDTO Data { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu Nombre"), MinLength(2, ErrorMessage = "Favor de usar al menos 2 caracteres para escribir tu nombre"), MaxLength(50, ErrorMessage = "Favor de no usar más de 50 caracteres para escribir tu nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu Apellido Paterno"), MinLength(2, ErrorMessage = "Favor de usar al menos 2 caracteres para escribir tu apellido paterno"), MaxLength(50, ErrorMessage = "Favor de no usar más de 50 caracteres para escribir tu apellido paterno")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu Apellido Materno"), MinLength(2, ErrorMessage = "Favor de usar al menos 2 caracteres para escribir tu apellido materno"), MaxLength(50, ErrorMessage = "Favor de no usar más de 50 caracteres para escribir tu apellido materno")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar tu CURP"), StringLength(18, ErrorMessage = "Favor de introducir una CURP de 18 caracteres")]
        public string CURP { get; set; }
        [Required(ErrorMessage = "Favor de proporcionar una fecha de nacimiento")]
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Favor de indicar tu escuela de procedencia"),MinLength(6, ErrorMessage = "Favor de usar al menos 6 caracteres para describir tu escuela de procedencia"), MaxLength(50, ErrorMessage = "Favor de no usar más de 100 caracteres para describir tu escuela de procedencia")]
        public string School { get; set; }

        //Courses
        public IEnumerable<SelectListItem> ValidCourses { get; set; }
        public CourseDTO Course { get; set; }
        [Required(ErrorMessage = "Favor de seleccionar el tipo de curso")]
        public int CourseTypeID { get; set; }
        public string CourseName { get; set; }

        //Support
        public SupportDTO Support { get; set; }
        public string Issue { get; set; }
        public IEnumerable<SelectListItem> IssueTypes { get; set; }

        //Group
        public GroupDTO Group { get; set; }
        public string Classroom { get; set; }
        public string GroupName { get; set; }
        public string ScheduleGroup { get; set; }
        public int Capacity { get; set; }
        public int Overflow { get; set; }
        public DateTime Date_Group { get; set; }

    }
}
