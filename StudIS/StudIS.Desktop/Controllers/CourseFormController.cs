using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using StudIS.Services;
using StudIS.DAL;
using StudIS.DAL.Repositories;

namespace StudIS.Desktop.Controllers
{
    public class CourseFormController
    {
        private readonly CourseServices _courseServices;
        private readonly UserServices _userServices;

        public CourseFormController(CourseServices courseServices, UserServices userServices)
        {
            _courseServices = courseServices;
            _userServices = userServices;
        }

        private void getLecturersAndStudents(out List<User> lecturers, out List<User> students)
        {
            var users = _userServices.GetAllUsers();
            lecturers = users.Where(t => t is Lecturer).ToList();
            students = users.Where(t => t is Student).ToList();
        }

        public void OpenFormNewCourse()
        {
            var course = new Course();
            List<User> lecturers, students;
            getLecturersAndStudents(out lecturers, out students);

            var courseForm = new CourseForm(this, course, lecturers, students);
            courseForm.Show();
        }

        public void OpenFormEditCourse(int id)
        {
            var course = _courseServices.GetCourseById(id);
            List<User> lecturers, students;
            getLecturersAndStudents(out lecturers, out students);
            
            var courseForm = new CourseForm(this, course, lecturers, students);
            courseForm.Show();
        }

        public bool UpdateCourse(Course course)
        {
            _courseServices.UpdateCourse(course.Id, course.Name, course.Name, course.EctsCredits);
            return true;
        }

        public bool SaveCourse(Course course)
        {
            try
            {
                if (_courseServices.GetCourseByNaturalIdentifier(course.NaturalIdentifier) == null)
                {
                    _courseServices.CreateCourse(course.Name, course.NaturalIdentifier, course.EctsCredits);
                }
                else
                {
                    _courseServices.UpdateCourse(course.Id, course.NaturalIdentifier, course.NaturalIdentifier, course.EctsCredits);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCourse(int id)
        {
            var course = _courseServices.GetCourseById(id);

            if(course == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _courseServices.DeleteCourse(id);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
