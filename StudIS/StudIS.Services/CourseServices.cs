using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Services
{
    public class CourseServices
    {

        private ICourseRepository _courseRepository;

        public CourseServices(ICourseRepository courseRepository)
        {

            _courseRepository = courseRepository;

        }
        public List<Course> GetCoursesByUserId(int id)
        {
            var courses = _courseRepository.GetByUserId(id);
            if (courses == null)
                return null;

            var coursesList = courses.ToList();
            coursesList.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
            return coursesList;

        }

        public Course GetCourseById(int courseId) {
            return _courseRepository.GetById(courseId);
        }
    }
}
