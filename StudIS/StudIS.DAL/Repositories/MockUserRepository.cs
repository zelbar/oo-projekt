using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.Users;

namespace StudIS.DAL.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private Course MockCourse = new Course()
        {
            Id = 1,
            EctsCredits = 4,
            //
        };
        private User MockUser = new Student()
        {
            Id = 1,
            Name = "Tibor",
            Surname = "Žukina",
            NationalIdentificationNumber = "12345",
            UserCredentials = null,
            StudentIdentificationNumber = "0036412345",
            CoursesEnrolledIn = null
        };
        private Credentials MockCredentials = new Credentials()
        {
            //CredentialsUser = User,
            Email = "tibor@svemir.hr",
            PasswordHash = "123abc".GetHashCode().ToString()
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
    }
}
