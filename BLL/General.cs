using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class General
    {
        public static class Messages
        {
            public static int AddSuccess = 1;
            public static int EmptyArea = 2;
            public static int UpdateSuccess = 3;
            public static int ImageMissing = 4;
            public static int ExtensionError = 5;
            public static int GeneralError = 6;
            public static int UniqueCURPerror = 7;
            public static int UniqueUsernameError = 8;
            public static int UniqueBothError = 9;
            public static int ValidUser = 10;
            public static int MessingWithTheCode = 11;
            public static int AddSupportSuccess = 12;
            public static int FileMissing = 13;
            public static int ToS = 14;
        }
        public static class Action
        {
            public static int RegisterStudent = 1;
            public static int RegisterAdmin = 2;
            public static int DeleteAdmin = 3;
            public static int UpdateAdmin = 4;
            public static int AddSupport = 5;
            public static int AddKey = 6;
            public static int DeleteKey = 7;
            public static int AddSchedule = 8;
            public static int ModifySchedule = 9;
            public static int DeleteSchedule = 10;
            public static int UpdateKeycard = 11;
            public static int UpdateStudent = 12;
            public static int UpdateCourse = 13;
            public static int UpdatePrice = 14;
            public static int AddPrice = 15;
            public static int DeletePrice = 16;
            public static int AddCourse = 17;
            public static int AddGroup = 18;
            public static int UpdateGroup = 19;
            public static int DeleteGroup = 20;
        }
        public static class Tables
        {
            public static int Student = 1;
            public static int Users = 2;
            public static int Support = 3;
            public static int Keycard = 4;
            public static int Schedule = 5;
            public static int Courses = 6;
            public static int Prices = 7;
            public static int Groups = 8;
        }
        public static class AdminType
        {
            public static int GeneralUser = 0;
            public static int regularAdmin = 1;
            public static int AdminUPIS = 2;
            public static int AdminUDI = 3;
        }

        
    }
}
