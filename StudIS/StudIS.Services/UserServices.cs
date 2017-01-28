using StudIS.Models;
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

        public static bool IsUserAdministrator(User user)
        {
            if (user.GetType() == typeof(Administrator))
                return true;
            else return false;
        }

        public static bool IsUserLecturer(User user)
        {
            if (user.GetType() == typeof(Lecturer))
                return true;
            else return false;

        }

        public static bool IsUserStudent(User user)
        {
            if (user.GetType() == typeof(Student))
                return true;
            else return false;

        }

        public User CreateUser(User user)
        {
            return _userRepository.Create(user);
        }

        public IList<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public IList<Administrator> GetAllAdministrators()
        {
            return _userRepository.GetAllAdministrators();
        }

        public IList<Lecturer> GetAllLecturers()
        {
            return _userRepository.GetAllLecturers();
        }

        public IList<Student> GetAllStudents()
        {
            return _userRepository.GetAllStudents();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }

        public bool DeleteUserById(int id)
        {
            return _userRepository.DeleteById(id);
        }



    }
}
