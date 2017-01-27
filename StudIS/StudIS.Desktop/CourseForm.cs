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
using StudIS.Desktop.Controllers;

namespace StudIS.Desktop
{
    public partial class CourseForm : Form
    {
        private readonly CourseFormController _courseFormController;
        private Course _course;
        private readonly IList<User> _lecturers;
        private readonly IList<User> _students;
        
        public CourseForm(
            CourseFormController courseFormController,
            Course course,
            IList<User> lecturers,
            IList<User> students)
        {
            _courseFormController = courseFormController;
            _course = course;
            _lecturers = lecturers;
            _students = students;

            InitializeComponent();

            this.Name = _course.Name + "("+ _course.NaturalIdentifier + ")";
            this.nameTextBox.Text = _course.Name;
            this.naturalIdentifierTextBox.Text = _course.NaturalIdentifier;
            this.ectsCreditsNumericUpDown.Value = _course.EctsCredits;

            ((ListBox)lecturerscheckedListBox).DataSource = _lecturers;
            ((ListBox)lecturerscheckedListBox).DisplayMember = "FullName";

            ((ListBox)studentsCheckedListBox).DataSource = _students;
            ((ListBox)studentsCheckedListBox).DisplayMember = "FullName";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _course.Name = this.nameTextBox.Text;
            _course.NaturalIdentifier = this.naturalIdentifierTextBox.Text;
            _course.EctsCredits = (int)this.ectsCreditsNumericUpDown.Value;
            _course.LecturersInCharge = new List<Lecturer>();

            if (_course.Name.Length == 0 || _course.NaturalIdentifier.Length == 0)
            {
                MessageBox.Show("Nisu popunjena sva obavezna polja", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var success = _courseFormController.SaveCourse(_course);
            if (success)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Pohrana nije uspjela");
            }
        }
    }
}
