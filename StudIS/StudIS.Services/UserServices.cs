using StudIS.Models.RepositoryInterfaces;
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
        private IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }


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
        public User createUser(User user)
        {
            return _userRepository.Create(user);
        }

       

    }
}
