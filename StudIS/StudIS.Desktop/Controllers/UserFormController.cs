using System;
using StudIS.Models.Users;
using StudIS.Services;

namespace StudIS.Desktop.Controllers
{
    public class UserFormController
    {
        private readonly UserServices _userServices;
        private readonly CourseServices _courseServices;

        public UserFormController(UserServices userServices, CourseServices courseServices)
        {
            _userServices = userServices;
            _courseServices = courseServices;
        }

        public bool OpenFormNewUser(User user)
        {
            var existingUser = _userServices.GetUserByEmail(user.Email);

            if (existingUser != null)
            {
                return false;
            }
            
            var courses = _courseServices.GetAllCourses();
            var userForm = new UserForm(this, user, courses);
            userForm.Show();

            return true;
        }

        public bool OpenFormEditUser(string email)
        {
            var courses = _courseServices.GetAllCourses();
            var user = _userServices.GetUserByEmail(email);

            if (user == null)
            {
                return false;
            }

            var userForm = new UserForm(this, user, courses);
            userForm.Show();
            return true;
        }

        public bool DeleteUser(string email)
        {
            var user = _userServices.GetUserByEmail(email);

            if (user == null)
            {
                return false;
            }

            return _userServices.DeleteUserById(user.Id);
        }

        public bool SaveUser(User user)
        {
            try
            {
                if (_userServices.GetUserByEmail(user.Email) == null)
                {
                    _userServices.CreateUser(user);
                }
                else
                {
                    _userServices.UpdateUser(user);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
