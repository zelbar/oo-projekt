using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudIS.Web.Api.Models;
using StudIS.Services;
using StudIS.DAL.Repositories;
using StudIS.DAL;
using StudIS.Models.Users;
using StudIS.Models.RepositoryInterfaces;

namespace StudIS.Web.Api.Controllers
{
    public class LoginController : ApiController
    {
        private IUserRepository _usrRep;

        public LoginController(IUserRepository usrRep)
        {
            _usrRep = usrRep;
        }
        /// <summary>
        /// Returns simple student model for mobile application, returns null if the data is wrong or a user is not student
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [HttpGet]
        public SimpleStudentModel Index(String email, String passwordHash)
        {
            var service = new LoginService(_usrRep);

            var user = service.LoginUser(email, passwordHash);
            if (user == null)
                return null;
            else if (UserServices.isUserStudent(user))
                return new SimpleStudentModel((Student)user);
            else
                return null;

        }
    }
}
