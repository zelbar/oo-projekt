using StudIS.Models.RepositoryInterfaces;
using StudIS.Services;
using StudIS.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudIS.Web.Mvc.Controllers
{
    public class LoginController : Controller
    {

        private IUserRepository _usrRep;

        public LoginController(IUserRepository usrRep)
        {
            _usrRep = usrRep;
        }

        // GET: Login
        public ActionResult Index(Credentials credentials)
        {
            if (ModelState.IsValid)
            {
                var loginService = new LoginService(_usrRep);
                var encryptedPassword = EncryptionService.EncryptSHA1(credentials.Password);
                var user = loginService.LoginUser(credentials.Email, encryptedPassword);

                if (user == null || UserServices.isUserAdministrator(user))
                    return RedirectToAction("Index", "Home",new {error=true });
                else
                {
                    Session.Add("userId", user.Id);
                    Session.Add("email", user.Email);

                    if (UserServices.isUserStudent(user))
                    {
                        Session.Add("userType", "Student");
                        return RedirectToAction("Index", "Student");
                    }

                    if (UserServices.isUserLecturer(user))
                    {
                        Session.Add("userType", "Lecturer");
                        return RedirectToAction("Index", "Lecturer");
                    }
                }
            }

            return RedirectToAction("Index", "Home", new { error = true });
        }
    }
}