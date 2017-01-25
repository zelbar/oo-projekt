using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.Models.RepositoryInterfaces;
using StudIS.DAL;
using StudIS.DAL.Repositories;

namespace StudIS.Desktop.Controllers
{
    public class UserFormController
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public UserFormController(IUserRepository userRepository, ICourseRepository courseRepository)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public bool NewUser(string email, User user)
        {
            var existingUser = _userRepository.GetByEmail(email);

            if (existingUser != null)
            {
                throw new Exception();
                return false;
            }


            var courses = _courseRepository.GetAll();
            var userForm = new UserForm(this, user, courses);
            userForm.Show();

            return true;
        }

        public bool EditUser(string email)
        {
            var courses = _courseRepository.GetAll();
            var user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new Exception();
                return false;
            }

            var userForm = new UserForm(this, user, courses);
            userForm.Show();
            return true;
        }

        public bool DeleteUser(string email)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                throw new Exception();
                return false;
            }

            return _userRepository.DeleteById(user.Id);
        }

        public bool SaveUser(User user)
        {
            try
            {
                _userRepository.Update(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
