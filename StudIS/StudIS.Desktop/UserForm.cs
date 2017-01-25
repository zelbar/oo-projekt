using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudIS.Models;
using StudIS.Models.Users;
using StudIS.Models.RepositoryInterfaces;
using StudIS.DAL;
using StudIS.DAL.Repositories;
using StudIS.Desktop.Controllers;

namespace StudIS.Desktop
{
    public partial class UserForm : Form
    {
        private readonly UserFormController _userFormController;
        private User _user;

        public UserForm(
            UserFormController userFormController,
            User user, 
            IList<Course> courses)
        {
            _userFormController = userFormController;
            _user = user;

            this.nameTextBox.Text = user.Name;
            this.surnameTextBox.Text = user.Surname;
            this.nationalIdentificationNumberTextBox.Text = user.NationalIdentificationNumber;

            if (user is Student)
            {
                this.studentIdentificationNumberTextBox
                    .Text = ((Student)_user).StudentIdentificationNumber;
            }
            else
            {
                this.studentIdentificationNumberTextBox.Enabled = false;
            }

            if (_user is Administrator)
            {
                this.coursesCheckedListBox.Enabled = false;
                this.coursesGroupBox.Enabled = false;
            }

            this.emailTextBox.Text = _user.Email;

            ((ListBox)coursesCheckedListBox).DataSource = courses.ToList();
            ((ListBox)coursesCheckedListBox).DisplayMember = "NaturalIdentifier";

            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _user.Name = this.nameTextBox.Text;
            _user.Surname = this.surnameTextBox.Text;


            _userFormController.SaveUser(_user);
        }
    }
}
