using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.Services;
using System.Windows.Forms;

namespace StudIS.Desktop.Controllers
{
    public class LoginFormController
    {
        private readonly LoginService _loginService;
        private readonly MainFormController _mainFormController;

        public LoginFormController(LoginService loginService, MainFormController mainFormController)
        {
            _loginService = loginService;
            _mainFormController = mainFormController;
        }

        public bool Login(string email, string password)
        {
            var result = _loginService.LoginUser(email, password);

            if (result != null)
            {
                if (result.GetType() != typeof(Administrator))
                {
                    MessageBox.Show(result.FullName + " nije u ulozi administratora");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Neispravni podaci korisnika");
                return false;
            }
        }
    }
}
