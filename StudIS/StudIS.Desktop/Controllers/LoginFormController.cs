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
        private readonly MainFormController _mainFormController;
        private readonly LoginService _loginService;

        public LoginFormController(
            MainFormController mainFormController,
            LoginService loginService)
        {
            _mainFormController = mainFormController;
            _loginService = loginService;
        }

        public bool Login(string email, string password)
        {
            var passwordHash = EncryptionService.EncryptSHA1(password);
            var user = _loginService.LoginUser(email, passwordHash);

            if (user != null)
            {
                if (!UserServices.isUserAdministrator(user))
                {
                    MessageBox.Show(user.FullName + " nije u ulozi administratora", "Nedovoljna prava", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Neispravni podaci korisnika", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
