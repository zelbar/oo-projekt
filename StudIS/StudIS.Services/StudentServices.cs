using StudIS.Models.RepositoryInterfaces;
using StudIS.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Services
{
    public class StudentServices
    {
        private IUserRepository _userRepository;

        public StudentServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;



        }

        public Student getStudentdata(int id)
        {
            var user = _userRepository.GetById(id);
            if (user != null && UserServices.IsUserStudent(user))
                return (Student)user;
            return null;


        }
    }
}
