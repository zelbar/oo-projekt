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
            }
            else if (this.lecturerRadioButton.Checked)
            {
                user = new Lecturer();
            }
            else if (this.adminRadioButton.Checked)
            {
                user = new Administrator();
            }
            else
            {
                MessageBox.Show("Odaberite vrstu korisnika.");
                return false;
            }

            user.Email = email;
            return true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            User user;
            string email;

            var valid = getSelectedAccountTypeAndEmail(out user, out email);

            if (valid)
            {
                var success = _userFormController.OpenFormNewUser(user);
                if (!success)
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
                var success = _userFormController.OpenFormEditUser(email);
                if (!success)
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
                var success = _userFormController.DeleteUser(email);

                if (success)
                {
                    MessageBox.Show("Korisnik izbrisan!");
                }
                else
                {
                    MessageBox.Show("Korisnik s unesenom e-mail adresom ne postoji.");
                }
            }
        }
    }
}
