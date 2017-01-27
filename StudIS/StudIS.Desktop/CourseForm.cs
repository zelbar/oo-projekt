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

            ((ListBox)lecturerscheckedListBox).DataSource = _lecturers;
            ((ListBox)lecturerscheckedListBox).DisplayMember = "FullName";

            ((ListBox)studentsCheckedListBox).DataSource = _students;
            ((ListBox)studentsCheckedListBox).DisplayMember = "FullName";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //_courseFormController.Save();
        }
    }
}
