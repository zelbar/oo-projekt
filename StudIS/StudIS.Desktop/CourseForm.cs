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
        private readonly IList<Lecturer> _lecturers;
        private readonly IList<Student> _students;
        
        public CourseForm(
            CourseFormController courseFormController,
            Course course,
            IList<Lecturer> lecturers,
            IList<Student> students)
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

            ((ListBox)lecturersCheckedListBox).DataSource = _lecturers;
            ((ListBox)lecturersCheckedListBox).DisplayMember = "FullName";
            var checkedLecturersIds = course.LecturersInCharge
                .Select(x => x.Id).ToList();

            for (int i = 0; i < lecturersCheckedListBox.Items.Count; ++i)
            {
                var lecturer = (User)lecturersCheckedListBox.Items[i];
                if (checkedLecturersIds.Contains(lecturer.Id))
                {
                    lecturersCheckedListBox.SetItemChecked(i, true);
                }
            }

            ((ListBox)studentsCheckedListBox).DataSource = _students;
            ((ListBox)studentsCheckedListBox).DisplayMember = "FullName";
            var checkedStudentsIds = course.StudentsEnrolled
                .Select(x => x.Id).ToList();

            for (int i = 0; i < studentsCheckedListBox.Items.Count; ++i)
            {
                var lecturer = (User)studentsCheckedListBox.Items[i];
                if (checkedStudentsIds.Contains(lecturer.Id))
                {
                    studentsCheckedListBox.SetItemChecked(i, true);
                }
            }
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

            var checkedLecturersIndices = this.lecturersCheckedListBox.CheckedIndices;
            var checkedLecturers = new List<Lecturer>();
            foreach (int lecturerIndex in checkedLecturersIndices)
            {
                var lecturerId = ((Lecturer)this.lecturersCheckedListBox.Items[lecturerIndex]).Id;
                checkedLecturers.Add(_lecturers.First(x => x.Id == lecturerId));
            }

            var checkedStudentsIndices = this.lecturersCheckedListBox.CheckedIndices;
            var checkedStudents = new List<Student>();
            foreach (int studentIndex in checkedStudentsIndices)
            {
                var studentId = ((Student)this.studentsCheckedListBox.Items[studentIndex]).Id;
                checkedStudents.Add(_students.First(x => x.Id == studentId));
            }

            _course.LecturersInCharge = checkedLecturers;
            _course.StudentsEnrolled = checkedStudents;

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
