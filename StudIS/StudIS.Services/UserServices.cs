using StudIS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Services
{
    public class UserServices
    {
        public static Boolean isUserAdministrator(User user)
        {
            if (user.GetType() == typeof(Administrator))
                return true;
            else return false;


        }
        public static Boolean isUserLecturer(User user)
        {
            if (user.GetType() == typeof(Lecturer))
                return true;
            else return false;

        }
        public static Boolean isUserStudent(User user)
        {
            if (user.GetType() == typeof(Student))
                return true;
            else return false;

        }

       

    }
}
