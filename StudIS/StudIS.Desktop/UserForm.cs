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

        public UserForm(
            UserFormController userFormController,
            User user, 
            IList<Course> courses)
        {
            _userFormController = userFormController;
            InitializeComponent();

            this.nameTextBox.Text = user.Name;
            this.surnameTextBox.Text = user.Surname;
            this.nationalIdentificationNumberTextBox.Text = user.NationalIdentificationNumber;

            if (user is Student)
            {
                this.studentIdentificationNumberTextBox
                    .Text = ((Student)user).StudentIdentificationNumber;
            }
            else
            {
                this.studentIdentificationNumberTextBox.Enabled = false;
            }

            if (user is Administrator)
            {
                this.coursesCheckedListBox.Enabled = false;
                this.coursesGroupBox.Enabled = false;
            }

            this.emailTextBox.Text = user.Email;

            ((ListBox)coursesCheckedListBox).DataSource = courses.ToList();
            ((ListBox)coursesCheckedListBox).DisplayMember = "NaturalIdentifier";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //_userFormController.Save
        }
    }
}
