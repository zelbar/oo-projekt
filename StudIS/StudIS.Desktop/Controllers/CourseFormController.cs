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

        private void getLecturersAndStudents(out IList<Lecturer> lecturers, out IList<Student> students)
        {
            lecturers = _userServices.GetAllLecturers();
            students = _userServices.GetAllStudents();
        }

        public void OpenFormNewCourse()
        {
            var course = new Course();
            course.LecturersInCharge = new List<Lecturer>();
            course.StudentsEnrolled = new List<Student>();
            course.Components = new List<Component>();

            IList<Lecturer> lecturers;
            IList<Student> students;
            getLecturersAndStudents(out lecturers, out students);

            var courseForm = new CourseForm(this, course, lecturers, students);
            courseForm.Show();
        }

        public void OpenFormEditCourse(int id)
        {
            var course = _courseServices.GetCourseById(id);
            IList<Lecturer> lecturers;
            IList<Student> students;
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
                if (_courseServices.GetCourseById(course.Id) == null)
                {
                    _courseServices.CreateCourse(course.Name, course.NaturalIdentifier, course.EctsCredits);
                    _courseServices.UpdateLecturers(course.Id, course.LecturersInCharge);
                    _courseServices.UpdateStudents(course.Id, course.StudentsEnrolled);
                }
                else
                {
                    _courseServices.UpdateCourse(course.Id, course.Name, course.NaturalIdentifier, course.EctsCredits);
                    _courseServices.UpdateLecturers(course.Id, course.LecturersInCharge);
                    _courseServices.UpdateStudents(course.Id, course.StudentsEnrolled);
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
                    return _courseServices.DeleteCourse(id);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
