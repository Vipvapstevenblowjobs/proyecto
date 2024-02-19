using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class GroupBLL
    {
        GroupDAO dao = new GroupDAO();

        public bool AddGroup(GroupDTO model, int id_Admin)
        {
            Group g = new Group();  

            g.Group_Name = model.GroupName;
            g.Classroom = model.Classroom;
            g.id_Schedule = model.ScheduleID;
            g.id_course = model.CourseID;
            g.Capacity = model.Capacity;
            g.Overflow = model.Overflow;

            int ID = dao.AddGroup(g);
            if (ID!=0)
            {
                LogDAO.AddLog(General.Action.AddCourse, General.Tables.Groups, ID, id_Admin);
                return true;
            }
            else
            {
                return false;
            }

        }

        public void DeleteGroup(int ID, int id_Admin)
        {
            dao.DeleteGroup(ID);
            LogDAO.AddLog(General.Action.DeleteGroup,General.Tables.Groups,ID,id_Admin);
        }

        public GroupDTO GetGroupInfo()
        {
            GroupDTO groupDTO = new GroupDTO();
            groupDTO.Courses = dao.GetAvailableCourses();
            groupDTO.Schedules = dao.GetAvailableSchedules();
            return groupDTO;
        }

        public List<GroupDTO> GroupList()
        {
            return dao.GroupList();
        }

        public List<GroupDTO> GroupList(int ID)
        {
            return dao.GroupList(ID);
        }

        public bool IsGroupEmpty(int ID)
        {
            return dao.IsGroupEmpty(ID); ;
        }

        public bool ValidCourse(int courseID)
        {
            return dao.ValidCourse(courseID);
        }

        public bool ValidSchedule(int scheduleID)
        {
            return dao.ValidSchedule(scheduleID);
        }
    }
}
