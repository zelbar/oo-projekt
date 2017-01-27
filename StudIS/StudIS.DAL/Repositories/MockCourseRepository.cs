using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;

namespace StudIS.DAL.Repositories
{
    public class MockCourseRepository : ICourseRepository
    {
        private Course MockCourse = new Course()
        {
            Id = 1,
            Name = "Objektno oblikovanje",
            NaturalIdentifier = "ObjOblFER2016OO",
            EctsCredits = 5,
            Components = null,
            LecturersInCharge = null,
            StudentsEnrolled = null
        };

        public IList<Course> GetAll()
        {
            var rv = new List<Course>()
            {
                MockCourse,
                new Course()
                {
                    Id = 2,
                    Name = "Napredni algoritmi i strukture podataka",
                    NaturalIdentifier = "NASP-FER-2016OO",
                    EctsCredits = 5,
                    Components = null,
                    LecturersInCharge = null,
                    StudentsEnrolled = null
                }
            };
            return rv;
        }

        public Course Create(Course course)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByNaturalIdentifier(string naturalIdentifier)
        {
            throw new NotImplementedException();
        }

        public Course GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Course GetByNaturalIdentifier(string naturalIdentifier)
        {
            throw new NotImplementedException();
        }

        public IList<Course> GetByStudentEnroledId(int userId)
        {
            Course MockCourse = new Course()
            {
                Id = 1,
                Name = "Objektno oblikovanje",
                NaturalIdentifier = "ObjOblFER2016OO",
                EctsCredits = 5,
                Components = null,
                LecturersInCharge = null,
                StudentsEnrolled = null
            };
            Course MockCourse2 = new Course()
            {
                Id = 2,
                Name = "NASP",
                NaturalIdentifier = "NASPFER2016OO",
                EctsCredits = 5,
                Components = null,
                LecturersInCharge = null,
                StudentsEnrolled = null
            };
            var list = new List<Course>();
            list.Add(MockCourse);
            list.Add(MockCourse2);
            return list;
        }

        public Course Update(Course course)
        {
            throw new NotImplementedException();
        }

        public IList<Course> GetByLecturerInChargerId(int lecturerId)
        {
            throw new NotImplementedException();
        }
    }
}
