using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudIS.Desktop.Controllers;

namespace StudIS.Desktop
{
    public partial class MainForm : Form
    {
        private readonly MainFormController _mainFormController;
        private readonly LoginFormController _loginFormController;
        private readonly CourseFormController _courseFormController;

        public MainForm(
            MainFormController mainFormController, 
            LoginFormController loginFormController,
            CourseFormController courseFormController)
        {
            _mainFormController = mainFormController;
            _loginFormController = loginFormController;
            _courseFormController = courseFormController;

            var loginForm = new LoginForm(_loginFormController);
            loginForm.Show();

        }

        private void newButton_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
