using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using StudIS.DAL;
using StudIS.DAL.Repositories;

namespace StudIS.Desktop.Controllers
{
    public class CourseFormController
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CourseFormController(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        private void getLecturersAndStudents(out List<User> lecturers, out List<User> students)
        {
            var users = _userRepository.GetAll();
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
            var course = _courseRepository.GetById(id);
            List<User> lecturers, students;
            getLecturersAndStudents(out lecturers, out students);
            
            var courseForm = new CourseForm(this, course, lecturers, students);
            courseForm.Show();
        }

        public bool UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
            return true;
        }

        public bool SaveCourse(Course course)
        {
            try
            {
                if (_courseRepository.GetByNaturalIdentifier(course.NaturalIdentifier) == null)
                {
                    _courseRepository.Create(course);
                }
                else
                {
                    _courseRepository.Update(course);
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
            var course = _courseRepository.GetById(id);

            if(course == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _courseRepository.DeleteById(id);
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
