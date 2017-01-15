using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;

namespace StudIS.DAL.Repositories
{
    class MockCourseRepository : ICourseRepository
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
                MockCourse
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

        public IList<Course> GetByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Course Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
