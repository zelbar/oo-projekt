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
        private INHibernateService _nhService;

        public LoginController(INHibernateService nhService)
        {
            _nhService = nhService;
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
            INHibernateService nHib = _nhService;
            var repository = new UserRepository(nHib.OpenSession());
            var service = new LoginService(repository);

            var user = service.LoginUser(email, passwordHash);
            if (user == null)
                return null;
            else if (UserServices.isUserStudent(user))
                return new SimpleStudentModel((Student)user);
            else
                return null;

        }
        [HttpGet]
        public string Index(string email)
        {

            return "žabica"+email;
        }
    }
}
