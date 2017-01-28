using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.Models.RepositoryInterfaces;

namespace StudIS.DAL.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private static Course MockCourse = new Course()
        {
            Id = 1,
            Name = "Objektno oblikovanje",
            NaturalIdentifier = "ObjOblFER2016OO",
            EctsCredits = 5,
            Components = null,
            LecturersInCharge = null,
            StudentsEnrolled = null
        };
        private User MockUser = new Student()
        {
            Id = 1,
            Email = "tibor@svemir.hr",
            PasswordHash = "123abc".GetHashCode().ToString(),
            Name = "Tibor",
            Surname = "Žukina",
            NationalIdentificationNumber = "12345",
            StudentIdentificationNumber = "0036412345",
            CoursesEnrolledIn = new List<Course>() { MockCourse }
        };

        public IList<User> GetAll()
        {
            var rv = new List<User>()
            {
                MockUser
            };
            return rv;
        }

        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByNationalIdentificationNumber(string nationalIdentificationNumbe)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetByCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            return MockUser;
        }

        public User GetById(int id)
        {
            return MockUser;
        }

        public User GetByNationalIdentificationNumbe(string nationalIdentificationNumbe)
        {
            return MockUser;
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }

        IList<Student> IUserRepository.GetByCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public IList<Administrator> GetAllAdministrators()
        {
            throw new NotImplementedException();
        }

        public IList<Lecturer> GetAllLecturers()
        {
            throw new NotImplementedException();
        }

        public IList<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }
    }
}
