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


        public User create(User user)
        {
            throw new NotImplementedException();
        }

        public bool deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool deleteByNationalIdentificationNumbe(string nationalIdentificationNumbe)
        {
            throw new NotImplementedException();
        }

        public IList<User> getByCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public User getByEmail(string email)
        {
            return MockUser;
        }

        public User getById(int id)
        {
            return MockUser;
        }

        public User getByNationalIdentificationNumbe(string nationalIdentificationNumbe)
        {
            return MockUser;
        }

        public User update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
