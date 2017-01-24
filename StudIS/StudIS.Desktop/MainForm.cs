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
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.DAL;
using StudIS.DAL.Repositories;

namespace StudIS.Desktop
{
    public partial class MainForm : Form
    {
        private readonly MainFormController _mainFormController;
        private readonly LoginFormController _loginFormController;
        private readonly CourseFormController _courseFormController;
        private readonly UserFormController _userFormController;

        public MainForm(
            MainFormController mainFormController, 
            LoginFormController loginFormController,
            CourseFormController courseFormController,
            UserFormController userFormController)
        {
            _mainFormController = mainFormController;
            _loginFormController = loginFormController;
            _courseFormController = courseFormController;
            _userFormController = userFormController;

            var loginForm = new LoginForm(loginFormController);
            loginForm.Show();
            InitializeComponent();
        }

        private bool getSelectedAccountTypeAndEmail(out User user, out string email)
        {
            email = this.emailTextBox.Text;
            user = null;

            if (email.Length == 0)
            {
                MessageBox.Show("Unesite e-mail adresu.");
                return false;
            }

            if (this.studentRadioButton.Checked)
            {
                user = new Student();
                return true;
            }
            else if (this.lecturerRadioButton.Checked)
            {
                user = new Lecturer();
                return true;
            }
            else if (this.adminRadioButton.Checked)
            {
                user = new Administrator();
                return true;
            }
            else
            {
                MessageBox.Show("Odaberite vrstu korisnika.");
                return false;
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            User user;
            string email;

            var valid = getSelectedAccountTypeAndEmail(out user, out email);

            if (valid)
            {
                try
                {
                    var success = _userFormController.NewUser(email, user);
                }
                catch (Exception)
                {
                    MessageBox.Show("Korisnik s unesenom e-mail adresom već postoji.");
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            User user;
            string email;

            var valid = getSelectedAccountTypeAndEmail(out user, out email);

            if (valid)
            {
                try
                {
                    var success = _userFormController.EditUser(email);
                }
                catch(Exception)
                {
                    MessageBox.Show("Korisnik s unesenom e-mail adresom ne postoji.");
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            User user;
            string email;

            var valid = getSelectedAccountTypeAndEmail(out user, out email);

            if (valid)
            {
                try
                {
                    var success = _userFormController.DeleteUser(email);
                }
                catch (Exception)
                {
                    MessageBox.Show("Korisnik s unesenom e-mail adresom ne postoji.");
                }
            }
        }
    }
}
