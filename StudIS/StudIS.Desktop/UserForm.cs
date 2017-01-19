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

namespace StudIS.Desktop
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            IUserRepository userRepo = new MockUserRepository();
            ICourseRepository courseRepo = new MockCourseRepository();
            var user = userRepo.GetAll()[0];

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

            this.emailTextBox.Text = user.Email;

            ((ListBox)coursesCheckedListBox).DataSource = courseRepo.GetAll();
            ((ListBox)coursesCheckedListBox).DisplayMember = "NaturalIdentifier";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
