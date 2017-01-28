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
using StudIS.Services;

namespace StudIS.Desktop
{
    public partial class UserForm : Form
    {
        private readonly UserFormController _userFormController;
        private User _user;
        private readonly IList<Course> _courses;

        public UserForm(
            UserFormController userFormController,
            User user, 
            IList<Course> courses)
        {
            _userFormController = userFormController;
            _user = user;
            _courses = courses;

            InitializeComponent();

            this.Text = user.FullName + " (" + user.Email + ")";

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

            var checkedCoursesIds = new List<int>();
            if (_user is Student)
            {
                checkedCoursesIds = ((Student)_user)
                    .CoursesEnrolledIn.Select(x => x.Id).ToList();
            }
            else if (_user is Lecturer)
            {
                checkedCoursesIds = ((Lecturer)_user)
                    .CoursesInChargeOf.Select(x => x.Id).ToList();
            }

            ListBox coursesListBox = ((ListBox)coursesCheckedListBox);
            coursesListBox.DataSource = courses.ToList();
            coursesListBox.DisplayMember = "NaturalIdentifier";

            for (int i = 0; i < coursesListBox.Items.Count; ++i)
            {
                var course = (Course)coursesListBox.Items[i];
                if (checkedCoursesIds.Contains(course.Id))
                {
                    coursesCheckedListBox.SetItemChecked(i, true);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _user.Name = this.nameTextBox.Text;
            _user.Surname = this.surnameTextBox.Text;
            _user.NationalIdentificationNumber = this.nationalIdentificationNumberTextBox.Text;
            _user.Email = this.emailTextBox.Text;

            var password = this.passwordTextBox.Text;
            if (password.Length > 0)
            {
                _user.PasswordHash = EncryptionService.EncryptSHA1(password);
            }

            if (_user.Email.Length == 0 || _user.Name.Length == 0 || _user.Surname.Length == 0
                || _user.NationalIdentificationNumber.Length == 0 || 
                (_user.PasswordHash == null || _user.PasswordHash.Length == 0))
            {
                MessageBox.Show("Nisu popunjena sva polja", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var checkedCoursesIndices = this.coursesCheckedListBox.CheckedIndices;
            var checkedCourses = new List<Course>();
            foreach (int courseIndex in checkedCoursesIndices)
            {
                var courseId = ((Course)this.coursesCheckedListBox.Items[courseIndex]).Id;
                checkedCourses.Add(_courses.First(x => x.Id == courseId));
            }
            
            if(_user is Student)
            {
                Student student = (Student)_user;
                student.StudentIdentificationNumber = this.studentIdentificationNumberTextBox.Text;
                student.CoursesEnrolledIn = checkedCourses;
            }

            if(_user is Lecturer)
            {
                Lecturer lecturer = (Lecturer)_user;
                lecturer.CoursesInChargeOf = checkedCourses;
            }

            var success = _userFormController.SaveUser(_user);

            if (success)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Pohrana nije uspjela.");
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.passwordTextBox.TextLength > 0)
            {
                this.passwordLabel.Text = "Lozinka (*)";
            }
        }
    }
}
