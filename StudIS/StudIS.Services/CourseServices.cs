using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using System.Collections.Generic;
using System.Linq;

namespace StudIS.Services
{
    public class CourseServices
    {

        private ICourseRepository _courseRepository;
        private IUserRepository _userRepository;
        private IComponentRepository _componentRepository;

        public CourseServices(ICourseRepository courseRepository, IUserRepository userRepository, IComponentRepository componentRepository)
        {

            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _componentRepository = componentRepository;

        }

        public IList<Course> GetAllCourses()
        {
            return _courseRepository.GetAll();
        }

        public Course GetCourseByNaturalIdentifier(string naturalIdentifier)
        {
            return _courseRepository.GetByNaturalIdentifier(naturalIdentifier);
        }

        public List<Course> GetCoursesByUserId(int id)
        {
            var student = _userRepository.GetById(id);
            if (student == null || !UserServices.IsUserStudent(student))
                return null;

            var courses = _courseRepository.GetByStudentEnroledId(id);
            if (courses == null)
                return null;

            var coursesList = courses.ToList();
            coursesList.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
            return coursesList;

        }

        public List<Course> GetCoursesByLecturerId(int id)
        { 
            var lecturer= _userRepository.GetById(id);
            if (lecturer==null || !UserServices.IsUserLecturer(lecturer))
                return null;

            var courses = _courseRepository.GetByLecturerInChargerId(id);
            if (courses == null)
                return null;

            var coursesList = courses.ToList();
            coursesList.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
            return coursesList;

        }

        public Course GetCourseById(int courseId)
        {
            return _courseRepository.GetById(courseId);
        }

        public Course CreateCourse(string name, string naturalIdentifier, int ectsCredits)
        {
            var course = new Course()
            {
                Name = name,
                NaturalIdentifier = naturalIdentifier,
                EctsCredits = ectsCredits
            };
            return _courseRepository.Create(course);

        }


        public Course UpdateCourse(int courseId, string name, string naturalIdentifier, int ectsCredits)
        {
            var course = _courseRepository.GetById(courseId);
            if (course == null)
                return null;

            course.Name = name;
            course.NaturalIdentifier = naturalIdentifier;
            course.EctsCredits = ectsCredits;
            return _courseRepository.Update(course);

        }

        public bool DeleteCourse(int id)
        {
            return _componentRepository.DeleteById(id);
        }
        public Course AddLecturer(int courseId, int lecturerId)
        {
            var course = _courseRepository.GetById(courseId);
            var lecturer = _userRepository.GetById(lecturerId);

            if (course == null || lecturer == null || !UserServices.IsUserLecturer(lecturer))
                return null;
            course.LecturersInCharge.Add((Lecturer)lecturer);
            return _courseRepository.Update(course);
        }

        public Course RemoveLecturer(int courseId, int lecturerId)
        {
            var course = _courseRepository.GetById(courseId);
            var lecturer = _userRepository.GetById(lecturerId);

            if (course == null || lecturer == null || !UserServices.IsUserLecturer(lecturer))
                return null;
            course.LecturersInCharge.Remove((Lecturer)lecturer);
            return _courseRepository.Update(course);
        }


        public Course AddStudent(int courseId, int studentId)
        {
            var course = _courseRepository.GetById(courseId);
            var student = _userRepository.GetById(studentId);

            if (course == null || student == null || !UserServices.IsUserStudent(student))
                return null;
            course.StudentsEnrolled.Add((Student)student);
            return _courseRepository.Update(course);
        }

        public Course RemoveStudent(int courseId, int studentId)
        {
            var course = _courseRepository.GetById(courseId);
            var student = _userRepository.GetById(studentId);

            if (course == null || student == null || !UserServices.IsUserStudent(student))
                return null;
            course.StudentsEnrolled.Remove((Student)student);
            return _courseRepository.Update(course);
        }


        public Course AddComponent(int courseId, int componentId)
        {
            var course = _courseRepository.GetById(courseId);
            var component = _componentRepository.GetById(courseId);

            if (course == null || component == null)
                return null;
            course.Components.Add(component);
            return _courseRepository.Update(course);
        }

        public Course RemoveComponent(int courseId, int componentId)
        {
            var course = _courseRepository.GetById(courseId);
            var component = _componentRepository.GetById(courseId);

            if (course == null || component == null)
                return null;
            course.Components.Remove(component);
            return _courseRepository.Update(course);
        }

    }
}
