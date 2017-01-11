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
            NaturalIdentifier = "FER2016OO",
            EctsCredits = 5,
            Components = null,
            LecturersInCharge = null,
            StudentsEnrolled = null
        };
        public Course create(Course course)
        {
            throw new NotImplementedException();
        }

        public bool deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool deleteByNaturalIdentifier(string naturalIdentifier)
        {
            throw new NotImplementedException();
        }

        public Course getById(int id)
        {
            throw new NotImplementedException();
        }

        public Course getByNaturalIdentifier(string naturalIdentifier)
        {
            throw new NotImplementedException();
        }

        public IList<Course> getByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Course update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
